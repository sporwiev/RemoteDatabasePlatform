using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace Seva
{
    /// <summary>
    /// Логика взаимодействия для CreateTable.xaml
    /// </summary>
    public partial class CreateTable : Window
    {



        public CreateTable()
        {
            InitializeComponent();
        }

       
        private void CrColumn(object sender, RoutedEventArgs e)
        {
            //SqlSend.TextWrapping = TextWrapping.Wrap;
            //SqlSend.Text = "CREATE TABLE test (ID int, Name varchar(255), Age int);";
        }
  
        private void Button_Click(object sender,RoutedEventArgs e)
        {
            /*try
            {
                *//*if (SqlSend.Text != "")
                {
                    int i = 0;
                    string txt = "";
                    string ty = "";
                    foreach (var item in SqlSend.Text)
                    {
                        i++;
                        txt += item.ToString();
                        if (i == 12)
                        {
                            ty = txt;
                            break;
                        }

                    }
                    
                    switch (ty)
                    {
                        case "CREATE TABLE":
                            crTable();
                            break;
                        case "create table":
                            crTable();
                            break;
                        default:
                            MessageBox.Show("Ошибка: Возможно вы записали запрос на создания таблицы в разных регистрах или же запрос не соотвествует созданию таблицы");
                            txt = string.Empty;
                            ty = string.Empty;
                            break;

                    }*//*
                    
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }
        private void crTable()
        {
            /*try
            {
                int index = SqlSend.Text.IndexOf(";");
                
                if (SqlSend.Text.Length - 1 == index)
                {
                    DB dB = new DB();
                    MySqlCommand mySqlCommand = new MySqlCommand(SqlSend.Text, dB.getConnection()); //Запрос + Открытие подключения
                    dB.OpenConnection();

                    if (mySqlCommand.ExecuteNonQuery() != 1)
                    {
                        MessageBox.Show("Table created");
                        this.Hide();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();

                    }
                    else
                    {
                        MessageBox.Show("Table not created");
                    }
                }
                else
                {
                    MessageBox.Show("Вы можете вписать запрос только на создание таблицы");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }*/
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            createColumn();
        }
        public void createColumn()
        {
            List<string> columns = new List<string>() {"INT","VARCHAR","TEXT","DATE"};
            List<string> attr = new List<string> {"---" ,"BINARY", "UNSIGNED", "UNSIGNED_ZEROFILL", "on update CURRENT_TIMESTAMP" };
            List<string> index = new List<string>() {"---","PRIMARY","UNIQUE","INDEX","FULLTEXT","SPATIAL"};

            List<string> collationtype = new List<string> {"---","armscii8_bin",
  "armscii8_general_ci",
  "ascii_bin",
  "ascii_general_ci",
  "big5_bin",
  "big5_chinese_ci",
  "binary",
  "cp1250_bin",
  "cp1250_croatian_ci",
  "cp1250_czech_cs",
  "cp1250_general_ci",
  "cp1250_polish_ci",
  "cp1251_bin",
  "cp1251_bulgarian_ci",
  "cp1251_general_ci",
  "cp1251_general_cs",
  "cp1251_ukrainian_ci",
  "cp1256_bin",
  "cp1256_general_ci",
  "cp1257_bin",
  "cp1257_general_ci",
  "cp1257_lithuanian_ci",
  "cp850_bin",
  "cp850_general_ci",
  "cp852_bin",
  "cp852_general_ci",
  "cp866_bin",
  "cp866_general_ci",
  "cp932_bin",
  "cp932_japanese_ci",
  "dec8_bin",
  "dec8_swedish_ci",
  "eucjpms_bin",
  "eucjpms_japanese_ci",
  "euckr_bin",
  "euckr_korean_ci",
  "gb18030_bin",
  "gb18030_chinese_ci",
  "gb18030_unicode_520_ci",
  "gb2312_bin",
  "gb2312_chinese_ci",
  "gbk_bin",
  "gbk_chinese_ci",
  "geostd8_bin",
  "geostd8_general_ci",
  "greek_bin",
  "greek_general_ci",
  "hebrew_bin",
  "hebrew_general_ci",
  "hp8_bin",
  "hp8_english_ci",
  "keybcs2_bin",
  "keybcs2_general_ci",
  "koi8r_bin",
  "koi8r_general_ci",
  "koi8u_bin",
  "koi8u_general_ci",
  "latin1_bin",
  "latin1_danish_ci",
  "latin1_general_ci",
  "latin1_general_cs",
  "latin1_german1_ci",
  "latin1_german2_ci",
  "latin1_spanish_ci",
  "latin1_swedish_ci",
  "latin2_bin",
  "latin2_croatian_ci",
  "latin2_czech_cs",
  "latin2_general_ci",
  "latin2_hungarian_ci",
  "latin5_bin",
  "latin5_turkish_ci",
  "latin7_bin",
  "latin7_estonian_cs",
  "latin7_general_ci",
  "latin7_general_cs",
  "macce_bin",
  "macce_general_ci",
  "macroman_bin",
  "macroman_general_ci",
  "sjis_bin",
  "sjis_japanese_ci",
  "swe7_bin",
  "swe7_swedish_ci",
  "tis620_bin",
  "tis620_thai_ci",
  "ucs2_bin",
  "ucs2_croatian_ci",
  "ucs2_czech_ci",
  "ucs2_danish_ci",
  "ucs2_esperanto_ci",
  "ucs2_estonian_ci",
  "ucs2_general_ci",
  "ucs2_general_mysql500_ci",
  "ucs2_german2_ci",
  "ucs2_hungarian_ci",
  "ucs2_icelandic_ci",
  "ucs2_latvian_ci",
  "ucs2_lithuanian_ci",
  "ucs2_persian_ci",
  "ucs2_polish_ci",
  "ucs2_roman_ci",
  "ucs2_romanian_ci",
  "ucs2_sinhala_ci",
  "ucs2_slovak_ci",
  "ucs2_slovenian_ci",
  "ucs2_spanish2_ci",
  "ucs2_spanish_ci",
  "ucs2_swedish_ci",
  "ucs2_turkish_ci",
  "ucs2_unicode_520_ci",
  "ucs2_unicode_ci",
  "ucs2_vietnamese_ci",
  "ujis_bin",
  "ujis_japanese_ci",
  "utf16_bin",
  "utf16_croatian_ci",
  "utf16_czech_ci",
  "utf16_danish_ci",
  "utf16_esperanto_ci",
  "utf16_estonian_ci",
  "utf16_general_ci",
  "utf16_german2_ci",
  "utf16_hungarian_ci",
  "utf16_icelandic_ci",
  "utf16_latvian_ci",
  "utf16_lithuanian_ci",
  "utf16_persian_ci",
  "utf16_polish_ci",
  "utf16_roman_ci",
  "utf16_romanian_ci",
  "utf16_sinhala_ci",
  "utf16_slovak_ci",
  "utf16_slovenian_ci",
  "utf16_spanish2_ci",
  "utf16_spanish_ci",
  "utf16_swedish_ci",
  "utf16_turkish_ci",
  "utf16_unicode_520_ci",
  "utf16_unicode_ci",
  "utf16_vietnamese_ci",
  "utf16le_bin",
  "utf16le_general_ci",
  "utf32_bin",
  "utf32_croatian_ci",
  "utf32_czech_ci",
  "utf32_danish_ci",
  "utf32_esperanto_ci",
  "utf32_estonian_ci",
  "utf32_general_ci",
  "utf32_german2_ci",
  "utf32_hungarian_ci",
  "utf32_icelandic_ci",
  "utf32_latvian_ci",
  "utf32_lithuanian_ci",
  "utf32_persian_ci",
  "utf32_polish_ci",
  "utf32_roman_ci",
  "utf32_romanian_ci",
  "utf32_sinhala_ci",
  "utf32_slovak_ci",
  "utf32_slovenian_ci",
  "utf32_spanish2_ci",
  "utf32_spanish_ci",
  "utf32_swedish_ci",
  "utf32_turkish_ci",
  "utf32_unicode_520_ci",
  "utf32_unicode_ci",
  "utf32_vietnamese_ci",
  "utf8_bin",
  "utf8_croatian_ci",
  "utf8_czech_ci",
  "utf8_danish_ci",
  "utf8_esperanto_ci",
  "utf8_estonian_ci",
  "utf8_general_ci",
  "utf8_general_mysql500_ci",
  "utf8_german2_ci",
  "utf8_hungarian_ci",
  "utf8_icelandic_ci",
  "utf8_latvian_ci",
  "utf8_lithuanian_ci",
  "utf8_persian_ci",
  "utf8_polish_ci",
  "utf8_roman_ci",
  "utf8_romanian_ci",
  "utf8_sinhala_ci",
  "utf8_slovak_ci",
  "utf8_slovenian_ci",
  "utf8_spanish2_ci",
  "utf8_spanish_ci",
  "utf8_swedish_ci",
  "utf8_turkish_ci",
  "utf8_unicode_520_ci",
  "utf8_unicode_ci",
  "utf8_vietnamese_ci",
  "utf8mb4_bin",
  "utf8mb4_croatian_ci",
  "utf8mb4_czech_ci",
  "utf8mb4_danish_ci",
  "utf8mb4_esperanto_ci",
  "utf8mb4_estonian_ci",
  "utf8mb4_general_ci",
  "utf8mb4_german2_ci",
  "utf8mb4_hungarian_ci",
  "utf8mb4_icelandic_ci",
  "utf8mb4_latvian_ci",
  "utf8mb4_lithuanian_ci",
  "utf8mb4_persian_ci",
  "utf8mb4_polish_ci",
  "utf8mb4_roman_ci",
  "utf8mb4_romanian_ci",
  "utf8mb4_sinhala_ci",
  "utf8mb4_slovak_ci",
  "utf8mb4_slovenian_ci",
  "utf8mb4_spanish2_ci",
  "utf8mb4_spanish_ci",
  "utf8mb4_swedish_ci",
  "utf8mb4_turkish_ci",
  "utf8mb4_unicode_520_ci",
  "utf8mb4_unicode_ci",
  "utf8mb4_vietnamese_ci"};
            TextBox textname = new TextBox();
            textname.Width = 100;
            textname.Height = 19;
            textname.Margin = new Thickness(0,0,0,10);
            textname.Background = Brushes.Transparent;
            textname.Foreground = Brushes.White;
            textname.BorderThickness = new Thickness(0, 0, 0, 1);
            Name.Children.Add(textname);
            ComboBox comboBoxtype = new ComboBox();
            for(int i = 0; i < columns.Count; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = columns[i];
                comboBoxtype.Items.Add(item);
            }
            comboBoxtype.SelectedIndex = 0;
            comboBoxtype.Margin = new Thickness(0, 0, 0, 10);
            Type.Children.Add(comboBoxtype);
            Button buttondel = new Button();
            buttondel.Margin = new Thickness(0,0,0,10);
            buttondel.Background = Brushes.Transparent;
            buttondel.Width = 19;
            buttondel.Height = 19;
            buttondel.BorderThickness = new Thickness(0);
            Image image = new Image();
            image.Width = 10;
            image.Height = 10;
            image.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\exit.png"));
            buttondel.Content = image;
            buttondel.Click += Buttondel_Click;
            del.Children.Add(buttondel);
            TextBox textlenght = new TextBox();
            textlenght.Width = 100;
            textlenght.Height = 19;
            textlenght.Margin = new Thickness(0, 0, 0, 10);
            textlenght.Background = Brushes.Transparent;
            textlenght.Foreground = Brushes.White;
            textlenght.BorderThickness = new Thickness(0, 0, 0, 1);
            Lenght.Children.Add(textlenght);
            ComboBox comboBoxcoll = new ComboBox();
            for (int i = 0; i < collationtype.Count; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = collationtype[i];
                comboBoxcoll.Items.Add(item);
            }
            comboBoxcoll.SelectedIndex = 0;
            comboBoxcoll.Margin = new Thickness(0, 0, 0, 10);
            Collation.Children.Add(comboBoxcoll);
            ComboBox comboBoxattr = new ComboBox();
            for (int i = 0; i < attr.Count; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = attr[i];
                comboBoxattr.Items.Add(item);
            }
            comboBoxattr.SelectedIndex = 0;
            comboBoxattr.Margin = new Thickness(0, 0, 0, 10);
            Attributes.Children.Add(comboBoxattr);
            CheckBox boxnull = new CheckBox();
            boxnull.Width = 20;
            boxnull.Height = 19;
            boxnull.VerticalContentAlignment = VerticalAlignment.Center;
            boxnull.Margin = new Thickness(0,0,0,20);
            boxnull.Background = Brushes.Transparent;
            Null.Children.Add(boxnull);
            ComboBox comboBoxindex = new ComboBox();
            for (int i = 0; i < index.Count; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = index[i];
                comboBoxindex.Items.Add(item);
            }
            comboBoxindex.SelectedIndex = 0;
            comboBoxindex.Margin = new Thickness(0, 0, 0, 10);
            Index.Children.Add(comboBoxindex);
            CheckBox boxai = new CheckBox();
            boxai.Width = 20;
            boxai.Margin = new Thickness(0, 0, 0, 10);
            boxai.Background = Brushes.Transparent;
            boxai.Height = 19;
            boxai.VerticalContentAlignment = VerticalAlignment.Center;
            A_I.Children.Add(boxai);
            TextBox textcomm = new TextBox();
            textcomm.Width = 100;
            textcomm.Height = 19;
            textcomm.Margin = new Thickness(0, 0, 0, 10);
            textcomm.Background = Brushes.Transparent;
            textcomm.Foreground = Brushes.White;
            textcomm.BorderThickness = new Thickness(0, 0, 0, 1);
            Comments.Children.Add(textcomm);
            ComboBox comboBoxvirt = new ComboBox();
            


        }


        
        private void Buttondel_Click(object sender, RoutedEventArgs e)
        {
            Button delele = sender as Button;
            int ind = del.Children.IndexOf(delele);
            for(int i = 0;i < paramert.Children.Count; i++) 
            { 
                StackPanel panel = paramert.Children[i] as StackPanel;
                panel.Children.RemoveAt(ind);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            createColumn();
            createColumn();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB dB = new DB();
                string table = "CREATE TABLE " + "`" + dB.conn.Database.ToString() + "`.`" + tableName.Text + "`(";
                List<string> names = new List<string>();
                List<string> types = new List<string>();
                List<string> lenghts = new List<string>();
                List<string> collations = new List<string>();
                List<string> attributes = new List<string>();
                List<string> nulls = new List<string>();
                List<string> indexs = new List<string>();
                List<string> ais = new List<string>();
                List<string> commentss = new List<string>();

                for (int i = 1; i < Name.Children.Count; i++)
                {
                    TextBox box = Name.Children[i] as TextBox;
                    names.Add(box.Text);
                }
                for (int i = 1; i < Type.Children.Count; i++)
                {
                    ComboBox box = Type.Children[i] as ComboBox;
                    ComboBoxItem item = box.SelectedItem as ComboBoxItem;
                    if (item != null)
                    {
                        types.Add(item.Content.ToString());
                    }
                    else
                    {
                        types.Add("");
                    }

                }
                for (int i = 1; i < Lenght.Children.Count; i++)
                {
                    TextBox box = Lenght.Children[i] as TextBox;
                    lenghts.Add(box.Text == null ? "" : "(" + box.Text + ")");
                }
               

                for (int i = 1; i < Collation.Children.Count; i++)
                {
                    ComboBox box = Collation.Children[i] as ComboBox;
                    ComboBoxItem item = box.SelectedItem as ComboBoxItem;
                    if (item != null)
                    {
                        collations.Add(item.Content.ToString());
                    }
                    else
                    {
                        collations.Add("");
                    }
                }
                for (int i = 1; i < Attributes.Children.Count; i++)
                {
                    ComboBox box = Attributes.Children[i] as ComboBox;
                    ComboBoxItem item = box.SelectedItem as ComboBoxItem;
                    if (item != null)
                    {
                        attributes.Add(item.Content.ToString());
                    }
                    else
                    {
                        attributes.Add("");
                    }
                }
                for (int i = 1; i < Null.Children.Count; i++)
                {
                    CheckBox box = Null.Children[i] as CheckBox;
                    if ((bool)box.IsChecked)
                    {
                        nulls.Add("NULL");
                    }
                    else
                    {
                        nulls.Add("");
                    }
                }
                for (int i = 1; i < Index.Children.Count; i++)
                {
                    ComboBox box = Index.Children[i] as ComboBox;
                    ComboBoxItem item = box.SelectedItem as ComboBoxItem;
                    if (item != null)
                    {
                        indexs.Add(item.Content.ToString());
                    }
                    else
                    {
                        indexs.Add("");
                    }
                }
                for (int i = 1; i < A_I.Children.Count; i++)
                {

                    CheckBox box = A_I.Children[i] as CheckBox;
                    if ((bool)box.IsChecked)
                    {
                        ais.Add("AUTO_INCREMENT");
                    }
                    else
                    {
                        ais.Add("");
                    }
                }
                for (int i = 1; i < Comments.Children.Count; i++)
                {
                    TextBox box = Comments.Children[i] as TextBox;
                    commentss.Add(box.Text);
                }

                for (int i = 0; i < nulls.Count; i++)
                {
                    string ind = indexs[i] == "---" ? "" : indexs[i] + $" (`{names[i]}`))";
                    string comm = commentss[i] == null ? "" : "COMMENT " + commentss[i]; 
                    string leng = lenghts[i] == null ? "" : "(" + lenghts[i] + ")";
                    table += "`" + names[i] + "` " + types[i] + " " + leng + " " + attributes[i] == "---" ? "" : attributes[i] + " " + nulls[i] + " " + ais[i] + " " + comm + ", " + ind;


                }
                table += "ENGINE = InnoDB";
                MessageBox.Show(table);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString() + " ");
            }
        }
    }
}
