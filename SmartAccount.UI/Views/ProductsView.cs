using System;
using System.Windows.Forms;
using SmartAccount.Business.Services;

namespace SmartAccount.UI.Views
{
    public partial class ProductsView : UserControl
    {
        private ProductService _productService;
        
        public ProductsView()
        {
            InitializeComponent();
            _productService = new ProductService();
        }
        
        private void ProductsView_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        
        private void LoadData()
        {
            dgvProducts.DataSource = _productService.GetAllProducts();
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
