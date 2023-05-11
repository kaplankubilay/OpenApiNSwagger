using NSwagGrocerySdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace FormClientApp
{
    public partial class Form1 : Form
    {
        private GroceryClient _groceryClient;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        //TODO: This line of code loads data into the 'groceryDBDataSet.GroceryItem' table.You can move, or remove it, as needed.
        //    this.groceryItemTableAdapter.Fill(this.groceryDBDataSet.GroceryItem);
        }

        private void btn_rapor_Click(object sender, EventArgs e)
        {
            GetGroceryItemList();
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            var getGroceryClient = CreateClient();
            await getGroceryClient.AddGroceryItemAsync(new GroceryItem
            {
                Name = NameTxtBox.Text,
                Description = DescriptionTxtBox.Text,
                Quantity = Convert.ToInt32(QuantityTxtBox.Text)
            });

            GetGroceryItemList();
        }

        private GroceryClient CreateClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImtrYXBsYW4iLCJzdWIiOiJra2FwbGFuIiwianRpIjoiOGI0N2VjZiIsImF1ZCI6WyJodHRwOi8vbG9jYWxob3N0OjYxNjEiLCJodHRwczovL2xvY2FsaG9zdDo0NDM4OCIsImh0dHA6Ly9sb2NhbGhvc3Q6NTA1NiIsImh0dHBzOi8vbG9jYWxob3N0OjcxMTciXSwibmJmIjoxNjgzNzI2MTgwLCJleHAiOjE2OTE2NzQ5ODAsImlhdCI6MTY4MzcyNjE4MCwiaXNzIjoiZG90bmV0LXVzZXItand0cyJ9.g7RvVs5MtlSKux674lpxu91cJL-uP2zp58T6ePDsUBM");

            var groceryClient = new GroceryClient("https://localhost:7117", client);

            return groceryClient;
        }

        private async void GetGroceryItemList()
        {
            var getGroceryClient = CreateClient();
            var items = await getGroceryClient.GetGroceryItemsAsync();
            var asd = (List<GroceryItem>)items.Data;
            groceryItemBindingSource.DataSource = asd;
        }
    }
}
