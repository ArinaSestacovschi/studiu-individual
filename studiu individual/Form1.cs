using studiu_individual.Entities;
using System.Windows.Forms;

namespace studiu_individual
{
    public partial class Form1 : Form
    {
        private readonly DataBaseContext _db;
        public Form1()
        {
            _db = new DataBaseContext();
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee()
            {
                first_name = textBox2.Text,
                last_name = textBox3.Text,
                email = textBox4.Text,
                salary = int.Parse(textBox5.Text),
            };
            _db.Employees.Add(emp);
            ApplyChanges();
            ClearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int employeeId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                Employee empToUpdate = _db.Employees.Find(employeeId);

                empToUpdate.first_name = textBox2.Text;
                empToUpdate.last_name = textBox3.Text;
                empToUpdate.email = textBox4.Text;
                empToUpdate.salary = int.Parse(textBox5.Text);

                ApplyChanges();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Selectati un angajat pentru editare !");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           


            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int employeeId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                Employee empToDelete = _db.Employees.Find(employeeId);
                _db.Employees.Remove(empToDelete);

                ApplyChanges();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Selectati un angajat pentru stergere !");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _db.Employees.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                textBox2.Text = selectedRow.Cells["first_name"].Value.ToString();
                textBox3.Text = selectedRow.Cells["last_name"].Value.ToString();
                textBox4.Text = selectedRow.Cells["email"].Value.ToString();
                textBox5.Text = selectedRow.Cells["salary"].Value.ToString();
            }
        }
        private void ApplyChanges()
        {
            _db.SaveChanges();
            dataGridView1.DataSource = _db.Employees.ToList();
        }
        private void ClearFields()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
