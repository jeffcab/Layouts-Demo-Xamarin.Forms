using System;
using Xamarin.Forms;

namespace XamarinFormsLayouts
{
	public class LayoutsDemoPage: TabbedPage
	{
		public LayoutsDemoPage ()
		{
			Children.Add (new StackLayoutDemo ());
			Children.Add (new AbsoluteLayoutDemo ());
			Children.Add (new RelativeLayoutDemo ());
			Children.Add (new GridLayoutDemo ());
			Children.Add (new ContentViewLayoutDemo ());
			Children.Add (new ScrollViewLayoutDemo ());
			Children.Add (new FrameLayoutDemo ());
		}
	}

	public class StackLayoutDemo : ContentPage {
		public StackLayoutDemo ()
		{
			var button = new Button {
				Text = "I'm a Button",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Black,

			};

			var label = new Label {
				Text = "I'm a Label",
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			var stack = new StackLayout {
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = { button, label }
			};

			Title = "Stack";
			Padding = 20;
			Content = stack;
		}
	}

	public class AbsoluteLayoutDemo : ContentPage {
		public AbsoluteLayoutDemo() {
			var boxRed = new BoxView {
				Color = Color.Red
			};

			var boxBlue = new BoxView {
				Color = Color.Blue
			};

			var boxYellow = new BoxView {
				Color = Color.Yellow
			};

			var boxPurple = new BoxView {
				Color = Color.Purple
			};

			var boxGreen = new BoxView {
				Color = Color.Green
			};

			AbsoluteLayout.SetLayoutFlags (boxRed, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds (boxRed, new Rectangle (0, 0, 0.35, 0.35));

			AbsoluteLayout.SetLayoutFlags (boxBlue, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds (boxBlue, new Rectangle (0.15, 0.15, 0.35, 0.35));

			AbsoluteLayout.SetLayoutFlags (boxYellow, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds (boxYellow, new Rectangle (0.30, 0.30, 0.35, 0.35));

			AbsoluteLayout.SetLayoutFlags (boxPurple, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds (boxPurple, new Rectangle (0.45, 0.45, 0.35, 0.35));

			AbsoluteLayout.SetLayoutFlags (boxGreen, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds (boxGreen, new Rectangle (0.60, 0.60, 0.35, 0.35));

			Title = "Absolute";
			Content = new AbsoluteLayout {
				Children = { boxRed, boxBlue, boxYellow, boxPurple, boxGreen }
			};
		}
	}

	public class RelativeLayoutDemo: ContentPage {
		public RelativeLayoutDemo() {

			var boxRed = new BoxView {
				Color = Color.Red
			};

			var boxBlue = new BoxView {
				Color = Color.Blue
			};

			var boxYellow = new BoxView {
				Color = Color.Yellow
			};

			var boxPurple = new BoxView {
				Color = Color.Purple
			};

			var relativeLayout = new RelativeLayout ();

			relativeLayout.Children.Add (boxRed, 
				Constraint.Constant (0),
				Constraint.Constant (0));

			relativeLayout.Children.Add (boxBlue,
				Constraint.RelativeToParent ((Parent) => Parent.Width - 40),
				Constraint.RelativeToParent ((Parent) => Parent.Height - 40));
			
			relativeLayout.Children.Add (boxYellow,
				Constraint.RelativeToParent (Parent => Parent.Width / 3),
				Constraint.RelativeToParent (Parent => Parent.Height / 3),
				Constraint.RelativeToParent (Parent => Parent.Width / 3),
				Constraint.RelativeToParent (Parent => Parent.Height / 3));

			relativeLayout.Children.Add (boxPurple,
				Constraint.RelativeToView (boxYellow, (Parent, Sibling) => Sibling.X),
				Constraint.RelativeToView (boxYellow, (Parent, Sibling) => Sibling.Y),
				Constraint.RelativeToView (boxYellow, (Parent, Sibling) => Sibling.Width / 3),
				Constraint.RelativeToView (boxYellow, (Parent, Sibling) => Sibling.Height / 3));
			
			Title = "Relative";
			Content = relativeLayout;

		}
	}

	public class GridLayoutDemo : ContentPage {
		public GridLayoutDemo() {

			var grid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition {Height = new GridLength( 1, GridUnitType.Star )},
					new RowDefinition {Height = new GridLength( 1, GridUnitType.Star )},
					new RowDefinition {Height = new GridLength( 1, GridUnitType.Star )}
				},
				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition {Width = new GridLength( 1, GridUnitType.Star )},
					new ColumnDefinition {Width = new GridLength( 1, GridUnitType.Star )},
					new ColumnDefinition {Width = new GridLength( 1, GridUnitType.Star )}
				}
			};

			var label1 = new Label {
				Text = "Cell 0, 0",
				BackgroundColor = Color.Red,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

			var label2 = new Label {
				Text = "Cell 2, 2",
				BackgroundColor = Color.Blue,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

			var label3 = new Label {
				Text = "Cell 1,0 With Span",
				BackgroundColor = Color.Yellow,
				TextColor = Color.Black,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

			grid.Children.Add (label1, 0, 0);
			grid.Children.Add (label2, 2, 2);
			grid.Children.Add (label3, 0, 1);
			Grid.SetColumnSpan (label3, 3);

			Title = "Grid";
			Content = grid;
		}
	}

	public class ContentViewLayoutDemo: ContentPage {
		public ContentViewLayoutDemo()
		{
			var contentView = new ContentView {
				Content = new Label {
					Text = "Hi, I'm a simple Label inside of a simple ContentView",
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand						
				}
			};

			Title = "ContentView";
			Content = contentView;
		}
	}

	public class ScrollViewLayoutDemo: ContentPage {
		public ScrollViewLayoutDemo()
		{
			var scrollView = new ScrollView {
				Content = new Label {
					Text = "Hello...... Hi....... Oi........ Hit the Quan......... This is a very long scrolling text.......... Are you not tired yet of waiting.........?"
				}
			};

			Title = "Scroll";
			Content = scrollView;
		}
	}

	public class FrameLayoutDemo : ContentPage {
		public FrameLayoutDemo() {
			var frameView = new Frame {
				Content = new Label {
					Text = "I've been Framed!",
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand,
				},
				OutlineColor = Color.Red
			};
			Title = "Frame";
			Content = frameView;
		}
	}
}

