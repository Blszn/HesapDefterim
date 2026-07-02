using System;
using System.Windows.Forms;
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
            dgvSettings.DataSource = _settingService.GetAllSettings();
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
