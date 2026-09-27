using System;
using System.Windows.Forms;
using System.Linq;
using SmartAccount.Business.Services;

namespace SmartAccount.UI.Views
{
    public partial class SettingsView : UserControl
    {
        private SettingService _settingService;
        
        private void btnBackupDb_Click(object sender, EventArgs e)
        {
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SmartAccount.db");
            if (!System.IO.File.Exists(dbPath))
            {
                MessageBox.Show("Veritabanı dosyası bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Veritabanı Dosyası (*.db)|*.db";
                sfd.FileName = "SmartAccountYedek_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".db";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.Copy(dbPath, sfd.FileName, true);
                        SmartAccount.Core.Data.SystemLogger.Log("Veritabanı yedeği alındı: " + sfd.FileName);
                        MessageBox.Show("Yedekleme başarıyla tamamlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Yedek alınırken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRestoreDb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yedekten dönmek mevcut tüm verilerinizi silecek ve seçtiğiniz yedeği yükleyecektir. İşleme devam edilsin mi?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Veritabanı Dosyası (*.db)|*.db";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SmartAccount.db");
                            System.IO.File.Copy(ofd.FileName, dbPath, true);
                            SmartAccount.Core.Data.SystemLogger.Log("Veritabanı yedekten dönüldü: " + ofd.FileName);
                            MessageBox.Show("Yedek başarıyla yüklendi. Değişikliklerin aktif olması için program yeniden başlatılacak.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Restart();
                            Environment.Exit(0);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Yedek yüklenirken hata oluştu (Dosya açık olabilir): " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        public SettingsView()
        {
            InitializeComponent();
            _settingService = new SettingService();
        }
        
        private void SettingsView_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        
        private void LoadData()
        {
            var settings = _settingService.GetAllSettings();
            dgvSettings.DataSource = settings.Select(s => new {
                ID = s.Id,
                AyarAdi = s.Key,
                Degeri = s.Value,
                Aciklamasi = s.Description
            }).ToList();
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}


