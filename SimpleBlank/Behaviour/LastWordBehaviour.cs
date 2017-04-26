using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace SimpleBlank.Behaviour
{
    public class LastWordBehaviour : Behavior<UIElement>
    {
        public static readonly DependencyProperty CaretIndexerProperty
            = DependencyProperty.Register(
                "CaretIndexer",
                typeof(int),
                typeof(LastWordBehaviour),
                new UIPropertyMetadata(null));

        public int CaretIndexer
        {
            get { return (int)GetValue(CaretIndexerProperty); }
            set { SetValue(CaretIndexerProperty, value); }
        }

     
    }
}







































//private static void InnerTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
//{
//    MessageBox.Show("Ура!");

//    TextBox box = d as TextBox;
//    if (d == null)
//    {
//        return;
//    }
//    box.TextChanged -= HandleTextCanged;

//    int newCaretIndex = (int)e.NewValue;
//    box.CaretIndex = newCaretIndex;
//    box.TextChanged += HandleTextCanged;
//}

//private static void HandleTextCanged(object sender, TextChangedEventArgs e)
//{
//    TextBox box = sender as TextBox;
//    SetBoundIndex(box, box.CaretIndex);
//}

//private static void SetBoundIndex(DependencyObject dp, int caretIndex)
//{
//    dp.SetValue(CaretIndexer, caretIndex);
//}

//using System.Windows;
//using System.Windows.Controls;

//namespace SimpleBlank.Behaviour
//{
//    public static class LastWordBehaviour
//    {
//        public static readonly DependencyProperty CaretIndexer
//            = DependencyProperty.RegisterAttached(
//                "CaretIndexer",
//                typeof(int),
//                typeof(LastWordBehaviour),
//                new PropertyMetadata(InnerTextChanged));

//        private static void InnerTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            MessageBox.Show("Ура!");

//            TextBox box = d as TextBox;
//            if (d == null)
//            {
//                return;
//            }
//            box.TextChanged -= HandleTextCanged;

//            int newCaretIndex = (int)e.NewValue;
//            box.CaretIndex = newCaretIndex;
//            box.TextChanged += HandleTextCanged;
//        }

//        private static void HandleTextCanged(object sender, TextChangedEventArgs e)
//        {
//            TextBox box = sender as TextBox;
//            SetBoundIndex(box, box.CaretIndex);
//        }

//        private static void SetBoundIndex(DependencyObject dp, int caretIndex)
//        {
//            dp.SetValue(CaretIndexer, caretIndex);
//        }
//    }
//}