﻿//
// ComboBoxDialog.cs
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
	public class ComboBoxDialog : Dialog
	{
		ComboBox comboBox;

		public ComboBoxDialog()
		{
			Title = "Xwt Combo Box Dialog";
			Width = 500;
			Height = 400;

			var vbox = new VBox ();
			Content = vbox;

			comboBox = new ComboBox ();
			vbox.PackStart (comboBox, false, false);

			AddItems ();
		}

		public void AddItems ()
		{
			for (int i = 0; i < 10; ++i) {
				var item = new ComboBoxItem ();
				comboBox.Items.Add (item, i.ToString ());
			}

			comboBox.SelectedIndex = 0;
		}

//		protected override void Dispose (bool disposing)
//		{
//			var store = comboBox.ItemsSource as ListStore;
//			if (store != null)
//				store.Dispose ();
//			comboBox.ItemsSource = null;
//			base.Dispose (disposing);
//		}
	}
}

