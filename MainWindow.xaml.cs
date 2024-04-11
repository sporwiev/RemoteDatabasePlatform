using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MySql.Data.MySqlClient;



namespace Seva
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public static bool isConnect = false;
        
        public MainWindow()
        {
            InitializeComponent();
            //Функция обновления данных получаемых с бд
            getTable();

            getData(Convertion(MenuTableBox.SelectedItem));
            //getUsers();
            request request = new request();
            

        }
        public void getUsers()
        {
            try
            {
                DB dB = new DB();
                MySqlCommand command = new MySqlCommand($"use mysql; SELECT user FROM user", dB.getConnection()); //Команда в которой мы пишем условие где id = значению введенного пользователем
                dB.OpenConnection();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = reader.GetString(0);
                        //usersView.Items.Add(item);
                    }
                }
                reader.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //Кнопка перехода в новое окно
        private void delete(object sender, RoutedEventArgs e)
        {
                try
                {
                    DB dB = new DB();
                 
                    MySqlCommand command = new MySqlCommand($"DELETE FROM {Convertion(MenuTableBox.SelectedItem)} WHERE `id` = {DelId.Text}", dB.getConnection()); //Команда в которой мы пишем условие где id = значению введенного пользователем
                    dB.OpenConnection();
                    
                
                    if (command.ExecuteNonQuery() == 1) // если запрос выдал 1 то норм
                    {
                        MessageBox.Show("Удалено");
                        getData(Convertion(MenuTableBox.SelectedItem));
                    }
                    else
                    {
                        MessageBox.Show("Не удалось");
                    }
                    dB.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        /*        private void update(object sender, RoutedEventArgs e)
                {
                    try
                    {
                        DB dB = new DB();
                        MySqlCommand command = new MySqlCommand($"UPDATE `user` SET `lastName`=  '{UpLastName.Text}',`firstName`= '{UpFirstName.Text}' WHERE `lastName` = '{UpBeforeLastName.Text}'", dB.getConnection());//Выполняем запрос в котором мы получаем данные вводимые пооьзователем, далее пропишем условие где lastName = вводимые данные
                        dB.OpenConnection(); // Открывем соеднинение
                        if (command.ExecuteNonQuery() == 1) // если 1 то круто все получилось, 0 запрос не прошел
                        {
                            MessageBox.Show("Изменено");
                            getData();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось");
                        }
                        dB.CloseConnection();//Закрываем соединение
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);//Есди сработало исключение, произойдет в том случае если Mamp будет выключен
                    }
                }*/

        private void getTable()
        {

                MenuTableBox.Items.Clear();
                DB dB = new DB();
                // Таблица в которую помещаем данные
                ComboBoxItem createTable = new ComboBoxItem();
                createTable.VerticalAlignment = VerticalAlignment.Center;
                createTable.Content = "Create table";
                createTable.Selected += CreateTable_Selected;
                MySqlCommand mySqlCommand = new MySqlCommand($"SHOW TABLES", dB.getConnection()); //Запрос + Открытие подключения
                dB.OpenConnection();
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        ComboBoxItem menuTableItems = new ComboBoxItem();
                        menuTableItems.VerticalAlignment = VerticalAlignment.Center;
                        menuTableItems.Content = reader.GetString(0);
                        menuTableItems.Selected += MenuTableItems_Selected;
                        MenuTableBox.Items.Add(menuTableItems);
                    }

                MenuTableBox.Items.Add(createTable);
                }
                MenuTableBox.SelectedItem = MenuTableBox.SelectedIndex = 0;
            
        }

        private void CreateTable_Selected(object sender, RoutedEventArgs e)
        {
            ComboBoxItem comboBoxItem = sender as ComboBoxItem;
            if(comboBoxItem.Content.ToString() == "Create table")
            {
                CreateTable table = new CreateTable();
                table.Show();
            }
        }

        private void MenuTableItems_Selected(object sender, RoutedEventArgs e)
        {
            DB dB = new DB();
            string item = sender.ToString();
            int index = item.IndexOf(":");
            string column = item.Remove(1, index + 1);
            string column1 = column.Remove(0, 1);
            MySqlCommand mySqlCommand = new MySqlCommand($"SELECT * FROM {column1}", dB.getConnection()); //Запрос + Открытие подключения
            dB.OpenConnection();
            if (MenuTableBox.Items[MenuTableBox.Items.Count-1].ToString() == "Create table")
            {
                CreateTable table = new CreateTable();
                table.Show();
            }
            else
            {
                getData(column1);
            }

        }
        public static string Convertion(object convert) 
        {
            if (convert == null)
            {
                return null;
            }
            else
            {
                string item = convert.ToString();
                int index = item.IndexOf(":");
                string column = item.Remove(1, index + 1);
                string column1 = column.Remove(0, 1);
                return column1;
            }
                
        }
        private void BtnPersonCreateAndUpdate_Click(Object sender, RoutedEventArgs e)
        {
            //Функция добавления пользователя
           /* add();
            //Функция обновления таблицы
            getData();
*/

        }

        public void getData(string table)
        {
            
                DB dB = new DB();
                // Таблица в которую помещаем данные
                DataTable dt = new DataTable();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();//Адаптер 
                MySqlCommand mySqlCommand = new MySqlCommand($"SELECT * FROM {table}", dB.getConnection()); //Запрос + Открытие подключения
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                
            // Присваивание Дефолтных значение вDataGridCustomers
            if (table == "Create table")
            {
                
            }
            else
            {
                mySqlDataAdapter.Fill(dt);//Присваеваем данные в таблицу
                
                DataGridCustom.ItemsSource = dt.DefaultView;

            }
            
        }
        public void add()
        {
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteAll(object sender, RoutedEventArgs e)
        {
                try
                {
                    DB dB = new DB();


                    var res = MessageBox.Show("Вы действительно хотите удалить все данные?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        DataTable dt = new DataTable();
                        MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
                        MySqlCommand mySqlCommand = new MySqlCommand($"DELETE FROM `{DelidTable.Text}` WHERE `id` >= 0", dB.getConnection());
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dt);//Присваеваем данные в таблицу
                        dataGrid.ItemsSource = dt.DefaultView;
                    getData(DelidTable.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }         
        private void timerTick(object sender, EventArgs e)
        {
            
        }

        DataGrid dataGrid = new DataGrid();
        private void DataGridCustomers_Loaded(object sender, RoutedEventArgs e)
        {

            /*DB dB = new DB();
            int count = 1;
            string names = "";

            MySqlCommand nameTable = new MySqlCommand("SHOW TABLES", dB.getConnection());
            dB.OpenConnection();
            MySqlDataReader reader = nameTable.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    dataGrid.CanUserAddRows = true;
                    dataGrid.CanUserDeleteRows = true;
                    dataGrid.CanUserResizeRows = true;
                    dataGrid.AutoGenerateColumns = true;
                    DataTable dt = new DataTable();
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
                    MySqlCommand tables = new MySqlCommand($"SELECT * FROM `{reader}`");
                    dB.OpenConnection();
                    mySqlDataAdapter.SelectCommand = tables;
                    mySqlDataAdapter.Fill(dt);//Присваеваем данные в таблицу
                    dataGrid.ItemsSource = dt.DefaultView;
                    Panel.Children.Add(dataGrid);

                }
            }
            else
            {
                MessageBox.Show("Таблицы не найдены, создать таблицу?", "Таблицы", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (MessageBoxButton.YesNo == MessageBoxButton.OK)
                {
                    CreateTable createTable = new CreateTable();
                    createTable.Show();
                }
            }
            reader.Close();
            */
        }

        private void CreateColumn_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            CreateColumn.Items.Clear();
            DB db = new DB();
           
            MySqlCommand Insert = new MySqlCommand($"USE favorite; SELECT * FROM {NameTable.Text};", db.getConnection());
            if (NameTable.Text != "")
            {
                db.OpenConnection();


                try
                {
                    string autoI = "";
                    int i = 0;
                    MySqlCommand auto = new MySqlCommand($"DESC {NameTable.Text}", db.getConnection());
                    MySqlDataReader reader = auto.ExecuteReader();
                    db.OpenConnection();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            i++;
                            if (reader.GetString(5) == "auto_increment")
                            {
                                autoI = reader.GetString(0);
                            }
                        }
                    }
                    reader.Close();
                    MySqlCommand nameTable = new MySqlCommand($"SHOW COLUMNS FROM {NameTable.Text}", db.getConnection());
                    db.OpenConnection();
                    MySqlDataReader reader1 = nameTable.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            if (reader1.GetString(0) == autoI)
                            {

                            }
                            else
                            {
                                Label label = new Label();
                                TextBox box = new TextBox();
                                /*Button del = new Button();
                                del.Content = "x";
                                del.FontSize = 5;
                                del.Width = 10;
                                del.Height = 10;*/
                                box.MaxLength = 100;
                                box.Width = 100;
                                label.Content = reader1.GetString(0);
                                CreateColumn.Items.Add(label);
                                CreateColumn.Items.Add(box);
                                //CreateColumn.Items.Add(del);
                            }
                        }
                    }
                    reader1.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("You not enterer table");
            }
        }
        string colunm,values,col,val,colu,valu;

        private void RemoveData(object sender, RoutedEventArgs e)
        {
            try
            {
                DB dB = new DB();
                string removeTable = Convertion(MenuTableBox.SelectedItem);
                
                if (MessageBox.Show("Do you really want to drop the table", "Remove table", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    DataTable dt = new DataTable();
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
                    MySqlCommand remove = new MySqlCommand($"DROP TABLE {removeTable}", dB.getConnection());
                    mySqlDataAdapter.SelectCommand = remove;
                    dB.OpenConnection();
                    mySqlDataAdapter.Fill(dt);//Присваеваем данные в таблицу
                    DataGridCustom.ItemsSource = dt.DefaultView;
                    getTable();
                    getData(removeTable);
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void UpdateSearchColumn(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateListBox.Items.Clear();
                DB db = new DB();
                if (UpdateSearchTable.Text != "")
                {

                    string autoI = "";
                    int i = 0;
                    MySqlCommand auto = new MySqlCommand($"DESC {UpdateSearchTable.Text}",db.getConnection());
                    db.OpenConnection();
                    MySqlDataReader reader = auto.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            i++;
                            if (reader.GetString(5) == "auto_increment")
                            {
                                autoI = reader.GetString(0);
                            }
                        }
                    }
                    reader.Close();
                    MySqlCommand nameTable = new MySqlCommand($"SHOW COLUMNS FROM {UpdateSearchTable.Text}", db.getConnection());
                    db.OpenConnection();
                    MySqlDataReader reader1 = nameTable.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1.GetString(0) == autoI)
                        {

                        }
                        else
                        {
                            Label label = new Label();
                            TextBox box = new TextBox();
                            box.MaxLength = 100;
                            box.Width = 100;

                            label.Content = reader1.GetString(0);
                            UpdateListBox.Items.Add(label);
                            UpdateListBox.Items.Add(box);
                        }
                    }


                    reader1.Close();

                }
                else
                {
                    MessageBox.Show("You not enterer table");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string upcol, upval, upcolval;

        private void Status(object sender, RoutedEventArgs e)
        {
            try
            {
                string privilage;
                DB dB = new DB();
                MySqlCommand insert = new MySqlCommand($"USE {/*Connected.database*/"favorite"}; SHOW GRANTS FOR '{/*Connected.username*/"root"}'@'{/*Connected.server*/"localhost"}';", dB.getConnection());
                dB.OpenConnection();
                
                MySqlDataReader reader = insert.ExecuteReader();
                while (reader.Read())
                {
                    privilage = reader.GetString(0);
                    int startindex = reader.GetString(0).IndexOf(" ");
                    int endindex = reader.GetString(0).IndexOf(" O");
                    int index = endindex - startindex;
                    string prig = privilage.Substring(startindex, index);
  


                }
                reader.Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void DeleteAll_Click(object sender, RoutedEventArgs e)
        {

        }
        List<string> limited = new List<string>() {"10","20","30","All"};
        private void Limited(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < 4; i++)
            {
                ComboBoxItem boxItem = new ComboBoxItem();
                boxItem.Content = limited[i];
                boxItem.Selected += SelectLimited;
                MenuLimitBox.Items.Add(boxItem);
            }
            MenuLimitBox.SelectedIndex = 0;
            

        }
        private void SelectLimited(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convertion(sender) == "All")
                {
                    getData(Convertion(MenuTableBox.SelectedItem));
                }
                else
                {
                    DB dB = new DB();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
                    MySqlCommand Limit = new MySqlCommand($"SELECT * FROM `{Convertion(MenuTableBox.SelectedItem)}` LIMIT {Convertion(sender)}", dB.getConnection());
                    dB.OpenConnection();
                    mySqlDataAdapter.SelectCommand = Limit;
                    mySqlDataAdapter.Fill(dt);//Присваеваем данные в таблицу
                    DataGridCustom.ItemsSource = dt.DefaultView;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Exits(object sender, RoutedEventArgs e)
        {
            
            if(MessageBox.Show("Вы действительно хотите выйти","",MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Close();
            }
            //this.Hide();
            //Connected connected = new Connected();
            //connected.Show();
        }

        private void BrowerOpen(object sender, RoutedEventArgs e)
        {
            
            Brower brower = new Brower();
            brower.Show();
        }

        private void PanelOpen(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void MenuTableBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //ComboBoxItem item = (ComboBoxItem)sender;
            //MessageBox.Show(MenuTableBox.Items[1].ToString());
            //NameTable.Text = item.Content.ToString();
        }

        private void mutiple_Click(object sender, RoutedEventArgs e)
        {

        }


        private void customparam_Selected(object sender, SelectionChangedEventArgs e)
        {
            
            TextBox box = new TextBox();
            box.Margin = new Thickness(0, 5, 0, 5);
            box.Background = Brushes.Transparent;
            box.Foreground = Brushes.White;
            box.BorderThickness = new Thickness(0, 0, 0, 1);
            Button button = new Button();
            button.Content = "multiple add data";
            button.Margin = new Thickness(0, 5, 0, 5);
            button.BorderThickness = new Thickness(0);
            button.Background = new SolidColorBrush(Color.FromRgb(42, 42, 42));
            button.Foreground = Brushes.White;

            switch (Convertion(sender))
            {
                case "multiple add data":
                    button.Click += mutiple_Click;
                    blockcustomparam.Children.Add(box);
                    blockcustomparam.Children.Add(button);
                    break;
            }
        }

        private void MenuTableBox_loaded(object sender, RoutedEventArgs e)
        {
            
            getTable();
            MenuTableBox.SelectedIndex = 0;
        }

        private void SendChanger(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Delete_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Up_click(object sender, RoutedEventArgs e)
        {
            upcol = string.Empty;
            upval = string.Empty;
            upcolval = string.Empty;
            try
            {
                for (int i = 0; i < UpdateListBox.Items.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        upcol = "`" + Convertion(UpdateListBox.Items[i]) + "`= ";
                        upcolval += upcol;
                    }
                    if (i % 2 == 1)
                    {
                        upval = "'" + Convertion(UpdateListBox.Items[i]) + "',";
                        upcolval += upval;
                    }
                }
                upcolval = upcolval.Remove(upcolval.Length - 1);
                
                DB db = new DB();
                DataTable dt = new DataTable();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
                MySqlCommand insert = new MySqlCommand($"UPDATE `{UpdateSearchTable.Text}` SET {upcolval}{UpdateSearchKey.Text}", db.getConnection());
                db.OpenConnection();
                MessageBox.Show(insert.CommandText);
                mySqlDataAdapter.SelectCommand = insert;
                if (insert.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Данные обновлены");
                    DataGridCustom.ItemsSource = dt.DefaultView;
                    getTable();
                    getData(UpdateSearchTable.Text);
                }
                else
                {
                    MessageBox.Show("Данные не обновлены");
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Send(object sender, RoutedEventArgs e)
        {
            try
            {
                DB dB = new DB();
                DataTable dt = new DataTable();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
                MySqlCommand send = new MySqlCommand(SendText.Text, dB.getConnection());
                mySqlDataAdapter.SelectCommand = send;
                dB.OpenConnection();
                mySqlDataAdapter.Fill(dt);//Присваеваем данные в таблицу
                DataGridCustom.ItemsSource = dt.DefaultView;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateData(object sender, RoutedEventArgs e)
        {
            getTable();
            getData(Convertion(MenuTableBox.SelectedItem));
            
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < CreateColumn.Items.Count; i++)
                {
                    if (i % 2 == 1)
                    {
                        colunm = CreateColumn.Items[i].ToString();
                        int index = colunm.IndexOf(":");
                        string column = colunm.Remove(1, index + 1);
                        string column1 = column.Remove(0, 1);
                        column = "'" + column1 + "', ";
                        col += column;

                    }
                    if (i % 2 == 0)
                    {
                        values = CreateColumn.Items[i].ToString();
                        int index1 = values.IndexOf(":");
                        string com = values.Remove(0, index1 + 1);
                        if (com.Length == 2)
                        {
                            com = "`" + com + "`, ";
                            val += com;
                        }
                        else
                        {
                            string com1 = com.Remove(0, 1);
                            com = "`" + com1 + "`, ";
                            val += com;
                        }

                    }


                }

                val = val.Remove(val.Length - 2);
                col = col.Remove(col.Length - 2);


                DB db = new DB();
                MySqlCommand insert = new MySqlCommand($"INSERT INTO `{NameTable.Text}`({val}) VALUES ({col})", db.getConnection());
                db.OpenConnection();
                
                if (insert.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Добавлено");
                    getData(NameTable.Text);
                }
                else
                {
                    MessageBox.Show("Не удвлось");
                }
                colunm = string.Empty;
                values = string.Empty;
                col = string.Empty;
                val = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            

        }
    }
}
