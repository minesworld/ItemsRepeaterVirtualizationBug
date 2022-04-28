**ItemsRepeaterVirtualizationBug**

As an ItemsRepeater does NOT recycle virtualized elements after sending the NotifyCollectionChangedAction.Reset change to its Layout that Layout needs to recycle Elements itself.

Either this 

- is a BUG of ItemsRepeater
- or the DOCUMENTATION is missing that fact

The App uses two versions of the Community.Toolkit.WinUI.Controls.WrapLayout:

- the current NuGet package (7.1.2)
- a custom version where 
  + a RecycleAllElements was added to WrapLayoutState which is optionally called on the Reset action
  + a "logging" mechanism

The App shows four different ways of presenting a List<Item>:

- a ListView with horizontal Community.Toolkit.WinUI.Controls.WrapPanel (NuGet)
- an ItemsRepeater with a horizontal StackLayout
- an ItemsRepeater with the Community.Toolkit.WinUI.Controls.WrapLayout (NuGet)
- an ItemsRepeater with the custom WrapLayout
  + the *"Recycle On Reset"* Checkbox activates the recycling
  + under *"Messages of FromCommunityToolkit.WrapLayout"* its messages will appear after clicking the *"Update"* button

***"Messages of FromCommunityToolkit.WrapLayout"***

Messages are shown in order newest on top. A message which follows one directly with the same content will be not shown.

- *"NextButtonClick"*, *"PreviousButtonClick"* as the name says
- the Name of the Method called
- *"MeasureOverride"* also list the Elements from 
  + context.GetOrCreateElementAt as *"@{index}>{content}"*
  + context.RecycleElement as *"R>{content}"* 

The App consists of two pages:

- BugPage1: the ListView and three ItemsRepeater use a Property of type List<Item> as their ItemsSource. Changing the current item is done via the *"Previous"* amd *"Next"* Buttons.
- BugPage2: the ListView and three ItemsRepeater are a DataTemplate which is used by a ListView which presents a List<ItemsList> where ItemsList holds a List<Item> which is uses as the DataTemplates DataType.

**Showing the Bug**

- go to either page and select different Items List, fore and back.
- ListView and the three ItemsRepeater should show the same content
- the Community.Toolkit.WinUI.Controls.WrapLayout (NuGet) will ALWAYS show the SAME first items
- the curstom WrapLayout will too unless the *"Recycle On Reset"* is activated
- the Messages show that the same (wrong) Elements are given back by context.GetOrCreateElementAt
