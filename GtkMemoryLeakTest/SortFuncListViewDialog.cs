//
// SortFuncListViewDialog.cs
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
	public class SortFuncListViewDialog : Dialog
	{
		TreeView listView;
		ListStore listStore;

		public SortFuncListViewDialog ()
		{
			Title = "Gtk Sort Func List View Box Dialog";
			WidthRequest = 500;
			HeightRequest = 400;

			var vbox = new HBox ();
			VBox.PackStart (vbox);

			listView = new TreeView ();
			listView.HeadersVisible = false;
			vbox.PackStart (listView);

			listStore = new ListStore (typeof(SortedListViewItem));
			listView.Model = listStore;

//			listStore.SetSortFunc (0,
//				(model, a, b) => string.Compare (GetItem (a).Id, GetItem (b).Id, StringComparison.Ordinal));
			listStore.SetSortFunc (0, SortListItems);

			listStore.SetSortColumnId (0, SortType.Ascending);

//			var textRenderer = new CellRendererText ();
//			listView.AppendColumn ("id", textRenderer,
//				(TreeViewColumn col, CellRenderer cell, TreeModel model, TreeIter iter) => {
//					((CellRendererText)cell).Text = GetItem (iter).Id;
//				}
//			);

			AddItems ();

			ShowAll ();
		}

		int SortListItems (TreeModel model, TreeIter a, TreeIter b)
		{
			return string.Compare (GetItem (a).Id, GetItem (b).Id, StringComparison.Ordinal);
		}

		void AddItems ()
		{
			for (int i = 9; i >= 0; --i) {
				listStore.AppendValues (new SortedListViewItem(i.ToString()));
			}
		}

		SortedListViewItem GetItem (TreeIter iter)
		{
			return (SortedListViewItem)listStore.GetValue (iter, 0);
		}
	}

	class SortedListViewItem
	{
		public SortedListViewItem (string id)
		{
			Id = id;
		}

		public string Id { get; set; }
	}
}

