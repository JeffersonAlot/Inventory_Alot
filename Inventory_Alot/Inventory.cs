using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Inventory_Alot
{
    public partial class frmAddProduct : Form
    {
        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;
        private int _Quantity;
        private double _SellPrice;
        private BindingSource showProductList;

        public frmAddProduct()
        {
            InitializeComponent();

            showProductList = new BindingSource();
        }

        public string Product_Name(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    throw new StringFormatException("Invalid Product Name."); 
                }
                else
                {
                    return name;
                }
            }
            catch (StringFormatException sfe)
            {
                MessageBox.Show(sfe.ToString());
            }
            finally
            {

            }

            return "";
        }
        public int Quantity(string qty)
        {
            try
            {
                if (!Regex.IsMatch(qty, @"^[0-9]"))
                {
                    throw new NumberFormatException("Invalid Quantity.");
                }
                else
                {
                    return Convert.ToInt32(qty); 
                }
            }
            catch (NumberFormatException nfe)
            {
                MessageBox.Show(nfe.ToString());
            }
            finally
            {

            }

            return 0;
        }
        public double SellingPrice(string price)
        {
            try
            {
                if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                {
                    throw new CurrencyFormatException("Invalid Currency.");
                }
                else
                {
                    return Convert.ToDouble(price); throw new CurrencyFormatException("Invalid Currency.");
                }
            }
            catch (CurrencyFormatException cfe)
            {
                MessageBox.Show(cfe.ToString());
            }
            finally
            {

            }

            return 0;
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[] { "Beverages",
                                                            "Bread/Bakery",
                                                            "Canned/Jarred Goods",
                                                            "Dairy",
                                                            "Frozen Goods",
                                                            "Meat",
                                                            "Personal Care",
                                                            "Other",};

            foreach (string Category in ListOfProductCategory)
            {
                cbCategory.Items.Add(Category);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            _ProductName = Product_Name(txtProductName.Text);
            _Category = cbCategory.Text;
            _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
            _Description = richTxtDescription.Text;
            _Quantity = Quantity(txtQuantity.Text);
            _SellPrice = SellingPrice(txtSellPrice.Text);
            showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
            _ExpDate, _SellPrice, _Quantity, _Description));
            gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewProductList.DataSource = showProductList;
        }
    }
}
