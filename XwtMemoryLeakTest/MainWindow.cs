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
using Xwt;

namespace XwtMemoryLeakTest
{
	public class MainWindow : Window
	{
		public MainWindow()
		{
			Title = "Xwt Test Application";
			Width = 500;
			Height = 400;

			var box = new VBox ();
			var comboBoxDialogButton = new Button ("Show Combo Box Dialog");
			comboBoxDialogButton.Clicked += ComboBoxDialogButtonClicked;
			box.PackStart (comboBoxDialogButton, false, false);

			var listViewDialogButton = new Button ("Show ListView Box Dialog");
			listViewDialogButton.Clicked += ListViewDialogButtonClicked;
			box.PackStart (listViewDialogButton, false, false);

			Content = box;

			CloseRequested += HandleCloseRequested;
		}

		void ComboBoxDialogButtonClicked (object sender, EventArgs e)
		{
			using (var dialog = new ComboBoxDialog ()) {
				dialog.Run (this);
			}
		}

		void ListViewDialogButtonClicked (object sender, EventArgs e)
		{
			using (var dialog = new ListViewDialog ()) {
				dialog.Run (this);
			}
		}

		void HandleCloseRequested (object sender, CloseRequestedEventArgs args)
		{
			Application.Exit ();
		}
	}
}

