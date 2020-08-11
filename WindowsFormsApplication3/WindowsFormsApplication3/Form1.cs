using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Clients clients;  
        Books books; 
        Genre genres; 
        int currentID;
        private void Book_Load(object sender, EventArgs e)
        {
            // Считываем все файлы в глобальные массивы, считывание вызывается из конструкторов этих классов
            Clients = new Clients();
            // persons.allPersons

            Genres = new Genres();

            books = new Books(Clients, Genres); // Чтобы инициализировать массив велосипедов, нужно знать персон и типы
            // Построение выпадающих списков для клиентов, работников, типов.
            buildComboBox(cs, 0);  // clients и workers - это название полей combobox на форме, а 0 и 1 - типы персон
            buildComboBox(ws, 1);
            buildTypeBox();
            // Готовимся показать форму. 
            int id = books.getMaxID();  // Получаем максимальный идентификатор, короче говоря, номер последнего велосипеда в списке
            Book b;
            if (id == 0) // Если номер - 0, то велосипедов в списке нет, показываем пустой на экране
            {
                id++;
                b = new Book(id); // Создаем новый велосипед с id=1
                books.addBook(b); // Добавляем велосипед к глобальному массиву
            }
            else
            {
                b = books.findByID(id); // Если велосипеды в списке есть, то ищем последний велосипед
            }
            fillForm(b); // Выводим велосипед b. Это или последний велосипед, или только что созданный новый
        }
        private void fillForm(Book b) // Заполнение формы велосипедом
        {
            currentID = b.ID; // Запоминаем номер велосипеда, который показываем на экране
            // Заполняем выпадающие списки
            if (b.client != null) cs.SelectedIndex = cs.FindStringExact(b.client.FIO);
            if (b.kniga != null) ws.SelectedIndex = ws.FindStringExact(b.kniga.FIO);
            if (b.genre != null) genreBook.SelectedIndex = genreBook.FindStringExact(b.genre.name);
            // Заполняем текстовые поля
           // problem.Text = b.problem;
            //solution.Text = b.solution;
            // Изменяем имя формы
            this.Text = "Велосипед №" + Convert.ToString(b.ID);
        }
        private void buildTypeBox() // Формируем выпадающий список типов 
        {
            foreach (Genre t in genres.getGenres()) // Функция types.getTypes() возвращает текущий список типов
            {
                genreBook.Items.Add(t.name);
            }
        }
        private void buildComboBox(ComboBox cmb, byte genre) // Формируем выпадающие списки клиентов и работников
        {
            foreach (Client p in clients.getClientsList(genre)) // Функция persons.getPersonsList(type) возвращает список или клиентов, или работников в зависимости от типа.
            {
                cmb.Items.Add(p.FIO);
            }
        }

        private void saveThisForm() // Сохраняем все, что есть сейчас на форме
        {
            Book b = books.findByID(currentID); // Ищем из списка тот велосипед, который показывается на форме
            // Сохраняем текстовые поля в объект велосипеда
            //b.problem = problem.Text;
            //b.solution = solution.Text;
            // Сохраняем данные о клиентах, работниках, типах
            /*
             * typeBike.SelectedItem - получает выбранный в списке элемент
             * typeBike.GetItemText - получает текст элемента
             * types.findByName - ищет тип по имени
             * Функции types.findByName и persons.findByFIO реализованы мною, см. соответствующие классы.
             */
            b.genre = genres.findByName(genreBook.GetItemText(genreBook.SelectedItem));
            b.client = clients.findByFIO(cs.GetItemText(cs.SelectedItem));
            b.kniga = clients.findByFIO(ws.GetItemText(ws.SelectedItem));
            books.ReplaceBook(b); // Обновляем информацию о велосипеде в классе
        }
        private void save_Click(object sender, EventArgs e)
        {
            saveThisForm();
            books.saveBooks();
            clients.saveClients();
            genres.saveGenres();
        }

        private void delBook_Click(object sender, EventArgs e)
        {
            Bike b = bikes.findByID(currentID);
            Bike next = bikes.getNext(currentID);
            if (next.ID == currentID) // Он последний
            {
                next = bikes.getPrev(currentID);
                if (next.ID == currentID) // Он был вообще один
                {
                    int ID = bikes.getMaxID() + 1;
                    next = new Bike(ID);
                    bikes.addBike(next);
                }
            }
            bikes.delBike(b);
            fillForm(next);
        }

        private void newBike_Click(object sender, EventArgs e)
        {
            saveThisForm();
            int ID = bikes.getMaxID() + 1;
            Bike b = new Bike(ID);
            bikes.addBike(b);
            fillForm(b);
            clients.SelectedIndex = 0;
            typeBike.SelectedIndex = 0;
            workers.SelectedIndex = 0;
        }
        private void next_Click(object sender, EventArgs e)
        {
            saveThisForm();
            Bike b = bikes.getNext(currentID);
            fillForm(b);
        }

        private void prev_Click(object sender, EventArgs e)
        {
            saveThisForm();
            Bike b = bikes.getPrev(currentID);
            fillForm(b);
        }
    }
}


    }
}
