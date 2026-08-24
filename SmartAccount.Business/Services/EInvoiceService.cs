using SmartAccount.Core.Entities;
using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace SmartAccount.Business.Services
{
    public class EInvoiceService
    {
        public void GenerateUblXml(Invoice invoice, string filePath)
        {
            // Temel UBL-TR formatında taslak bir E-Fatura XML oluşturulur.
            XNamespace cac = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
            XNamespace cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
            XNamespace defaultNs = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2";

            var xml = new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes"),
                new XElement(defaultNs + "Invoice",
                    new XAttribute(XNamespace.Xmlns + "cac", cac),
                    new XAttribute(XNamespace.Xmlns + "cbc", cbc),
                    new XElement(cbc + "UBLVersionID", "2.1"),
                    new XElement(cbc + "CustomizationID", "TR1.2"),
                    new XElement(cbc + "ProfileID", "TEMELFATURA"),
                    new XElement(cbc + "ID", invoice.InvoiceNumber),
                    new XElement(cbc + "CopyIndicator", "false"),
                    new XElement(cbc + "UUID", Guid.NewGuid().ToString()),
                    new XElement(cbc + "IssueDate", invoice.Date.ToString("yyyy-MM-dd")),
                    new XElement(cbc + "InvoiceTypeCode", "SATIS"),
                    new XElement(cbc + "DocumentCurrencyCode", "TRY"),
                    new XElement(cbc + "LineCountNumeric", invoice.Items?.Count.ToString() ?? "0"),
                    
                    new XElement(cac + "AccountingSupplierParty",
                        new XElement(cac + "Party",
                            new XElement(cac + "PartyName",
                                new XElement(cbc + "Name", "Bizim Şirket A.Ş.")
                            )
                        )
                    ),
                    new XElement(cac + "AccountingCustomerParty",
                        new XElement(cac + "Party",
                            new XElement(cac + "PartyIdentification",
                                new XElement(cbc + "ID", invoice.Customer?.TaxNumber ?? "11111111111")
                            ),
                            new XElement(cac + "PartyName",
                                new XElement(cbc + "Name", invoice.Customer?.FullName ?? "Bilinmeyen Müşteri")
                            )
                        )
                    ),
                    new XElement(cac + "LegalMonetaryTotal",
                        new XElement(cbc + "LineExtensionAmount", new XAttribute("currencyID", "TRY"), invoice.TotalAmount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)),
                        new XElement(cbc + "TaxExclusiveAmount", new XAttribute("currencyID", "TRY"), invoice.TotalAmount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)),
                        new XElement(cbc + "TaxInclusiveAmount", new XAttribute("currencyID", "TRY"), invoice.GrandTotal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)),
                        new XElement(cbc + "PayableAmount", new XAttribute("currencyID", "TRY"), invoice.GrandTotal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture))
                    )
                )
            );

            xml.Save(filePath);
        }
    }
}
