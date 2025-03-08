using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Library_System
{
    public partial class BookListForm : Form
    {
        private List<Book> books; // List to store books

        public BookListForm()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            // Sample book data
            books = new List<Book>
            {
                new Book { Title = "C# in Depth", Author = "Jon Skeet", Category = "Programming" },
                new Book { Title = "Python Crash Course", Author = "Eric Matthes", Category = "Programming" },
                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Category = "Fiction" },
                new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Category = "Fiction" }
            };

            // Bind data to DataGridView
            dgvBooks.DataSource = books;
            LoadCategories();
        }

        private void LoadCategories()
        {
            // Get unique categories and add to ComboBox
            var categories = books.Select(b => b.Category).Distinct().ToList();
            categories.Insert(0, "All"); // Add "All" option

            cmbCategoryFilter.DataSource = categories;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterBooks();
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterBooks();
        }

        private void FilterBooks()
        {
            string searchText = txtSearch.Text.ToLower();
            string selectedCategory = cmbCategoryFilter.SelectedItem?.ToString();

            var filteredBooks = books.Where(b =>
                (string.IsNullOrEmpty(searchText) || b.Title.ToLower().Contains(searchText) || b.Author.ToLower().Contains(searchText)) &&
                (selectedCategory == "All" || b.Category == selectedCategory)
            ).ToList();

            dgvBooks.DataSource = filteredBooks;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategoryFilter.SelectedIndex = 0;
            LoadBooks();
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Cell clicked: Row " + e.RowIndex + ", Column " + e.ColumnIndex);
        }
    }

    // Book Model
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
