using MySql.Data.MySqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static vizsga.MainWindow;
using System.Xml.Linq;
using System.Windows.Markup;

namespace vizsga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ConnectionString = "server=localhost;uid=root;database=versenyek";
        public MySqlConnection connection;
        public MySqlCommand command;

        public class Trainee
        {
            public Trainee(int id, string name, string school, int percentage, string versenyName)
            {
                Id = id;
                Name = name;
                School = school;
                Percentage = percentage;
                VersenyName = versenyName;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string School { get; set; }
            public int Percentage { get; set; }
            public string VersenyName { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            connection = new MySqlConnection(ConnectionString);
            fetchTrainees();
            fetchversenyNames();
        }

        public void fetchversenyNames()
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT id, nev FROM verseny";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = reader.GetString("nev");
                item.Tag = reader.GetInt16("id");
                edzok.Items.Add(item);
            }

            connection.Close();
        }

        public void fetchTrainees()
        {
            List<Trainee> Trainees = new List<Trainee>();

            trainees.ItemsSource = Trainees;
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT `diak`.*, `diak`.`nev` AS `diak` FROM `diak` LEFT JOIN `diak` ON `diak`.`verseny_id` = `diak`.`id`;";
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Trainees.Add(new Trainee(reader.GetInt32("id"), reader.GetString("nev"), reader.GetString("iskola"), reader.GetInt32("szazalek"), reader.GetString("diak")));
            }
            connection.Close();

            trainees.ItemsSource = Trainees;
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedversenyName = ((ComboBoxItem)edzok.SelectedItem).Tag.ToString();

                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO sportolok (nev, iskola, szazalek, verseny_id) VALUES (@nev, @iskola, @szazalek, @verseny_id)";
                command.Parameters.AddWithValue("@nev", name.Text);
                command.Parameters.AddWithValue("@iskola", school.Text;
                command.Parameters.AddWithValue("@szazalek", ;
                command.Parameters.AddWithValue("@versenyek_id", int.Parse(selectedversenyName));
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Sikeres Felvétel");

                fetchTrainees();

                name.Text = "";
                school.Text = "";
                percentage.Text = "";
                edzok.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }*/

        /*private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (trainees.SelectedItem is Trainee selectedTrainee)
            {
                try
                {
                    if (edzok.SelectedItem is ComboBoxItem selectedversenyName)
                    {
                        connection.Open();
                        command = connection.CreateCommand();
                        command.CommandText = "UPDATE sportolok SET nev = @nev, szuletesi_ev = @szuletesi_ev, sportag = @sportag, edzo_id = @edzo_id WHERE id = @id";
                        command.Parameters.AddWithValue("@nev", name.Text);
                        command.Parameters.AddWithValue("@szuletesi_ev", int.Parse(school.Text));
                        command.Parameters.AddWithValue("@sportag", percentage.Text);
                        command.Parameters.AddWithValue("@edzo_id", selectedversenyName.Tag);
                        command.Parameters.AddWithValue("@id", selectedTrainee.Id);
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Sikeres szerkesztés");

                        fetchTrainees();

                        name.Text = "";
                        school.Text = "";
                        percentage.Text = "";
                        edzok.SelectedItem = null;
                    }
                    else
                    {
                        MessageBox.Show("Kérlek válassz ki egy edzőt!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kérlek válassz ki egy sportolót a szerkesztéshez!");
            }
        }*/
    }
}