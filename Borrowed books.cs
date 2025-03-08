
using System;
using System.Windows.Forms;

namespace library_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Fix: Added the missing event handler for DataGridView cell clicks
        private void dgvBorrowedBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is not on the header row
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the value of the clicked cell
                string cellValue = dgvBorrowedBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                MessageBox.Show($"You clicked: {cellValue}", "Cell Clicked", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Optional: Handle text changed event for txtBorrower
        private void txtBorrower_TextChanged(object sender, EventArgs e)
        {
            // Example validation logic
            if (txtBorrower.Text.Length > 50)
            {
                MessageBox.Show("Borrower name is too long!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Example: Borrow Book Button Click Event
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtBorrower.Text))
            {
                MessageBox.Show("Please enter book title and borrower name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add data to DataGridView
            dgvBorrowedBooks.Rows.Add(txtTitle.Text, txtBorrower.Text, dtpBorrowDate.Value.ToShortDateString(), dtpReturnDate.Value.ToShortDateString());

            // Clear fields
            txtTitle.Clear();
            txtBorrower.Clear();
        }

        // Example: Clear Button Click Event
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtBorrower.Clear();
            dtpBorrowDate.Value = DateTime.Now;
            dtpReturnDate.Value = DateTime.Now;
        }

        // Example: Delete Record Button Click Event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBorrowedBooks.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvBorrowedBooks.SelectedRows)
                {
                    dgvBorrowedBooks.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
