## XwtMemoryLeakTest

### Show Combo Box dialog

Adding items to a combo box and then disposing its parent dialog does not free the combo box list store and ends up keeping the dialog alive.

	GLib.ToggleRef->
		Gtk.ListStore->
			Collections.Hashtable->
				Gtk.RowInsertedHandler->
					GtkBackend.ListStoreBackend->
						System.EventHandler->
							Xwt.ComboBox
							ComboBox.WidgetBackendHost
							Xwt.VBox->
								XwtMemoryLeakTest.ComboBoxDialog

### Show List View dialog

Adding a custom canvas cell view to a ListViewColumn and then disposing its parent dialog does not free the CanvasRenderer and ends up keeping the dialog alive.

	GLib.ToggleRef->
		GtkBackend.CanvasRenderer->
			XwtMemoryLeakTest.CustomCanvasCellView->
				Xwt.ListView->
					Xwt.ListStore
					Xwt.VBox->
						XwtMemoryLeakTest.ListViewDialog