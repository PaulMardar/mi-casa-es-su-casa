using iQuest.VendingMachine.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace iQuest.VendingMachine.Repo
{
    class SqlServerRepository : IProductRepository
    {
        SqlConnection sqlConnection;

        public SqlServerRepository(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void AddProduct(int columnId, string name, float price, int quantity)
        {
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("insert into Product values(" + columnId + ", '" + name + "'," + price + ", " + quantity + ")", sqlConnection);
            var reader = command.ExecuteReader();

            reader.Close();
            sqlConnection.Close();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            sqlConnection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("Select * from Product", sqlConnection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            List<Product> products = new List<Product>();

            foreach (var row in dataTable.AsEnumerable())
            {
                var id = (int)row["ProductId"];
                var name = row["Name"].ToString();
                var price = (float)Convert.ToSingle(row["Price"]);
                var quantity = (int)row["Quantity"];
                products.Add(new Product(id, name, price, quantity));
            }

            sqlConnection.Close();
            return products;
        }

        public IProduct GetProductById(int id)
        {
            sqlConnection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("Select * from Product where ProductId =" + id, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            List<Product> products = new List<Product>();
            foreach (var row in dataTable.AsEnumerable())
            {
                var productId = (int)row["ProductId"];
                var name = row["Name"].ToString();
                var price = (float)Convert.ToSingle(row["Price"]);
                var quantity = (int)row["Quantity"];
                sqlConnection.Close();

                return new Product(productId, name, price, quantity);
            }
            return null;
        }

        public bool isValid(int id)
        {
            sqlConnection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter(
                "Select * " +
                "From Product " +
                "Where ProductId = " + id, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            List<Product> products = new List<Product>();
            sqlConnection.Close();
            foreach (var row in dataTable.AsEnumerable())
            {
                return true;
            }
            return false;
        }

        public void ReduceProductQuantity(int columnId)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(
                String.Format(
                    "UPDATE Product " +
                    "SET Quantity = Quantity - 1 " +
                    "WHERE ProductId = {0} and " +
                    "Quantity > 0", columnId),
                sqlConnection);
            var reader = command.ExecuteReader();
            reader.Close();
            sqlConnection.Close();
        }
    }
}
