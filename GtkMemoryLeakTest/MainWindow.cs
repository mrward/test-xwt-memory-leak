//
// MainWindow.cs
//
// Author:
//       Matt Ward <matt.ward@xamarin.com>
//
// Copyright (c) 2016 Xamarin Inc. (http://xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
using System;
using Gtk;

namespace GtkMemoryLeakTest
{
	public class MainWindow: Gtk.Window
	{
		public MainWindow()
			: base (Gtk.WindowType.Toplevel)
		{
			Title = "Gtk Test Application";
			WidthRequest = 500;
			HeightRequest = 400;

			var box = new VBox ();
			var comboBoxDialogButton = new Button ("Show Combo Box Dialog");
			comboBoxDialogButton.Clicked += ComboBoxDialogButtonClicked;
			box.PackStart (comboBoxDialogButton, false, false, 0);

			var listViewDialogButton = new Button ("Show ListView Box Dialog");
			listViewDialogButton.Clicked += ListViewDialogButtonClicked;
			box.PackStart (listViewDialogButton, false, false, 0);

			var sortFuncListViewDialogButton = new Button ("Show SortFunc ListView Box Dialog");
			sortFuncListViewDialogButton.Clicked += SortFuncListViewDialogButtonClicked;
			box.PackStart (sortFuncListViewDialogButton, false, false, 0);

			DeleteEvent += OnDeleteEvent;

			Add (box);
			ShowAll ();
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}

		void ComboBoxDialogButtonClicked (object sender, EventArgs e)
		{
			var dialog = new ComboBoxDialog ();
			dialog.Run ();
			dialog.Destroy ();
		}

		void ListViewDialogButtonClicked (object sender, EventArgs e)
		{
			var dialog = new ListViewDialog ();
			dialog.Run ();
			dialog.Destroy ();
		}

		void SortFuncListViewDialogButtonClicked (object sender, EventArgs e)
		{
			var dialog = new SortFuncListViewDialog ();
			dialog.Run ();
			dialog.Destroy ();
		}
	}
}

