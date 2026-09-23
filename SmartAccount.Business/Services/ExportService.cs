using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SmartAccount.Core.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmartAccount.Business.Services
{
    public class ExportService
    {
        public ExportService()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public void ExportInvoicesToExcel(IEnumerable<Invoice> invoices, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Faturalar");
                
                // Başlıklar
                worksheet.Cell(1, 1).Value = "Fatura No";
                worksheet.Cell(1, 2).Value = "Tarih";
                worksheet.Cell(1, 3).Value = "";
                worksheet.Cell(1, 4).Value = "Durum";
                worksheet.Cell(1, 5).Value = "Tutar";
                
                var headerRange = worksheet.Range("A1:E1");
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                int row = 2;
                foreach (var invoice in invoices)
                {
                    worksheet.Cell(row, 1).Value = invoice.InvoiceNumber;
                    worksheet.Cell(row, 2).Value = invoice.Date.ToString("dd.MM.yyyy");
                    worksheet.Cell(row, 3).Value = invoice.Customer?.FullName ?? "";
                    
                    string status = invoice.Status == "Draft" ? "Taslak" :
                                    invoice.Status == "Paid" ? "" : "";
                                    
                    worksheet.Cell(row, 4).Value = status;
                    worksheet.Cell(row, 5).Value = invoice.GrandTotal;
                    worksheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00 ₺";
                    row++;
                }

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(filePath);
            }
        }

        public void ExportInvoicesToPdf(IEnumerable<Invoice> invoices, string filePath)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header().Text("Fatura Listesi Raporu").SemiBold().FontSize(20).FontColor(Colors.Blue.Darken2);

                    page.Content().PaddingVertical(1, Unit.Centimetre).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(3);
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(2);
                        });

                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).Text("Fatura No");
                            header.Cell().Element(CellStyle).Text("Tarih");
                            header.Cell().Element(CellStyle).Text("");
                            header.Cell().Element(CellStyle).Text("Durum");
                            header.Cell().Element(CellStyle).Text("Tutar");

                            static IContainer CellStyle(IContainer container)
                            {
                                return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                            }
                        });

                        foreach (var invoice in invoices)
                        {
                            table.Cell().Element(Block).Text(invoice.InvoiceNumber);
                            table.Cell().Element(Block).Text(invoice.Date.ToString("dd.MM.yyyy"));
                            table.Cell().Element(Block).Text(invoice.Customer?.FullName ?? "");
                            
                            string status = invoice.Status == "Draft" ? "Taslak" :
                                            invoice.Status == "Paid" ? "" : "";
                            
                            table.Cell().Element(Block).Text(status);
                            table.Cell().Element(Block).Text(invoice.GrandTotal.ToString("C2"));

                            static IContainer Block(IContainer container)
                            {
                                return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                            }
                        }
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Sayfa ");
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
            })
            .GeneratePdf(filePath);
        }
    }
}

