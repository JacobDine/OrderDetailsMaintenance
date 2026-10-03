using OrderDetailsMaintenance.Models.DataLayer;

namespace OrderDetailsMaintenance
{
    public partial class frmCustomerMaintenance : Form
    {
        private NorthwindContext _context;
        private Customer _customer;
        public frmCustomerMaintenance()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e) // jacob dine
        {
            var id = txtCustomerId.Text?.Trim();

            _context = new NorthwindContext();
            _customer = _context.Customers.Find(id);

            if (_customer != null)
            {
                txtCustomerId.Text = _customer.CustomerId;
                txtContact.Text = _customer.ContactName;
                txtAddress.Text = _customer.Address;
                txtCity.Text = _customer.City;
                txtCountry.Text = _customer.Country;
            }
            else
            {
                MessageBox.Show($"ID not found.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e) // jacob dine
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e) // jacob dine
        {
            var customerId = txtCustomerId.Text?.Trim();
            if (string.IsNullOrWhiteSpace(customerId))
            {
                MessageBox.Show("Customer ID is required.");
                return;
            }

            if (_context == null) _context = new NorthwindContext();

            _customer = new Customer
            {
                CustomerId = customerId,
                CompanyName = "Unknown Company",
                ContactName = txtContact.Text?.Trim(),
                Address = txtAddress.Text?.Trim(),
                City = txtCity.Text?.Trim(),
                Country = txtCountry.Text?.Trim()
            };

            _context.Customers.Add(_customer);
            _context.SaveChanges();
            MessageBox.Show("Customer created successfully.");
        }
    }
}