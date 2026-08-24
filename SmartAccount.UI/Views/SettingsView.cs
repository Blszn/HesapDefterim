using System;
using System.Windows.Forms;
using System.Linq;
using SmartAccount.Business.Services;

namespace SmartAccount.UI.Views
{
    public partial class SettingsView : UserControl
    {
        private SettingService _settingService;
        
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
                AyarAdı = s.Key,
                Değer = s.Value,
                Açıklama = s.Description
            }).ToList();
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
