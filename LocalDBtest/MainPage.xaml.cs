using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LocalDBtest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SQLite.Net.SQLiteConnection conn;
        int id = 0;

        public MainPage()
        {
            this.InitializeComponent();

            createDb();
        }

        private void createDb()
        {
            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "MoveForward.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath);
            //conn.CreateTable<S1>();
        }

        private void insertToDb()
        {
            var s = conn.Insert(new S1()
            {
                id = id+1,
                x = 2222,
                y = 2222,
                z = 2222,
                timestamp = 2222
            });
        }

        private void getDbContent()
        {
            var query = conn.Table<S1>();
            int x = 0;
            int id = 0;
            int y = 0;
            int z = 0;
            int timestamp = 0;

            foreach (var message in query)
            {
                id = message.id;
                x = message.x;
                y = message.y;
                z = message.z;
                timestamp = message.timestamp;
            }
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            insertToDb();
        }

        private void buttonGetContent_Click(object sender, RoutedEventArgs e)
        {
            getDbContent();
        }

        private void buttonCreateDb_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class S1
    {
        //[PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public int timestamp { get; set; }
    }
}
