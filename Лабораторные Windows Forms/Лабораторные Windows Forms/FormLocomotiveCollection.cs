using System;
using System.Drawing;
using System.Windows.Forms;
using Лабораторные_Windows_Forms.CollectionGenericObjects;
using Лабораторные_Windows_Forms.Drawing;

namespace Лабораторные_Windows_Forms
{
    public partial class FormLocomotiveCollection : Form
    {
        private readonly ICollectionGenericObjects<DrawingLocomotive> _collection;
        private AbstractCompany? _company;
        private readonly Random _random = new Random();

        public FormLocomotiveCollection()
        {
            InitializeComponent();
            _collection = new MassiveGenericObjects<DrawingLocomotive>();
            this.Shown += FormLocomotiveCollection_Shown;
        }

        private void FormLocomotiveCollection_Shown(object sender, EventArgs e)
        {
            // Принудительно задаём размеры, если PictureBox ещё не имеет размеров
            int width = pictureBoxParking.Width > 0 ? pictureBoxParking.Width : 800;
            int height = pictureBoxParking.Height > 0 ? pictureBoxParking.Height : 400;
            _company = new Depot(width, height, _collection);
            RefreshDisplay();
        }

        private void RefreshDisplay()
        {
            if (_company != null)
                pictureBoxParking.Image = _company.Show();
        }

        private Color GetColor()
        {
            ColorDialog dialog = new ColorDialog();
            // В некоторых версиях .NET свойство Title отсутствует, используем Text
            // dialog.Text = "Выберите цвет"; // если нужно, раскомментируйте
            if (dialog.ShowDialog() == DialogResult.OK)
                return dialog.Color;
            else
                return Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256));
        }

        // ========== КНОПКА: ДОБАВИТЬ ПРОСТОЙ ТЕПЛОВОЗ ==========
        private void buttonAddSimple_Click(object sender, EventArgs e)
        {
            if (_company == null) { MessageBox.Show("Депо не инициализировано"); return; }

            int speed = _random.Next(8, 15);
            double weight = _random.Next(100, 500);
            Color bodyColor = GetColor();
            var loco = new DrawingLocomotive(speed, weight, bodyColor, 3);

            if (_company + loco)
            {
                MessageBox.Show("Простой тепловоз добавлен");
                RefreshDisplay();
            }
            else
            {
                MessageBox.Show("Нет свободного места");
            }
        }

        // ========== КНОПКА: ДОБАВИТЬ ПРОДВИНУТЫЙ ТЕПЛОВОЗ ==========
        private void buttonAddSport_Click(object sender, EventArgs e)
        {
            if (_company == null) { MessageBox.Show("Депо не инициализировано"); return; }

            int speed = _random.Next(8, 15);
            double weight = _random.Next(100, 500);
            Color bodyColor = GetColor();
            Color additionalColor = GetColor();
            bool wheelOrnament = _random.Next(2) == 1;
            bool goldAccents = _random.Next(2) == 1;

            var loco = new DrawingSportLocomotive(speed, weight, bodyColor, 3,
                additionalColor, wheelOrnament, goldAccents);

            if (_company + loco)
            {
                MessageBox.Show("Продвинутый тепловоз добавлен");
                RefreshDisplay();
            }
            else
            {
                MessageBox.Show("Нет свободного места");
            }
        }

        // ========== КНОПКА: УДАЛИТЬ ОБЪЕКТ ПО ПОЗИЦИИ ==========
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (_company == null) return;

            if (!int.TryParse(textBoxPosition.Text, out int position))
            {
                MessageBox.Show("Введите число (позицию)");
                return;
            }

            if (_company - position)
            {
                MessageBox.Show($"Объект на позиции {position} удалён");
                RefreshDisplay();
            }
            else
            {
                MessageBox.Show("Не удалось удалить (неверная позиция или уже пусто)");
            }
            textBoxPosition.Clear();
        }

        // ========== КНОПКА: ПЕРЕДАТЬ СЛУЧАЙНЫЙ ОБЪЕКТ В FORM1 ==========
        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            if (_company == null) return;

            var randomLoco = _company.GetRandomObject();
            if (randomLoco == null)
            {
                MessageBox.Show("Нет объектов в коллекции");
                return;
            }

            Form1 testForm = new Form1();
            testForm.SetDrawingLocomotive(randomLoco);
            testForm.ShowDialog();

            // После закрытия формы обновляем отображение коллекции (она не изменилась)
            RefreshDisplay();
        }

        // ========== КНОПКА: ОБНОВИТЬ ОТОБРАЖЕНИЕ ==========
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDisplay();
        }
    }
}