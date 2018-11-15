<!-- default file list -->
*Files to look at*:

* **[BaseClass.cs](./CS/DXExample.Module/BaseClass.cs) (VB: [BaseClass.vb](./VB/DXExample.Module/BaseClass.vb))**
* [MarkAsReadViewController.cs](./CS/DXExample.Module/MarkAsReadViewController.cs) (VB: [MarkAsReadViewController.vb](./VB/DXExample.Module/MarkAsReadViewController.vb))
* [MySimpleUser.cs](./CS/DXExample.Module/MySimpleUser.cs) (VB: [MySimpleUser.vb](./VB/DXExample.Module/MySimpleUser.vb))
<!-- default file list end -->
# How to apply another appearance to reviewed objects


<p>This example demonstrates how to change the color of an object, which has been already seen by a current user in ListView. To accomplish this task, the following steps are performed:</p><p>1. Implemented the base class for all classes (named BaseClass) whose instances should be marked as read. It contains the Users property, which represents a collection of users who reviewed the current object;</p><p>2. Implemented the custom user class (MySimpleUser) to add a many-to-many association with the BaseClass class;</p><p>3. Implemented the Conditional Appearance rule for the BaseClass that changes the appearance of the reviewed objects;</p><p>4. Implemented ViewController (MarkAsReadViewController) to mark reviewed objects, i.e. to add the currently logged user to the BaseClass.Users collection.</p><p><strong>See Also:</strong><br />
<a href="http://documentation.devexpress.com/#Xaf/CustomDocument2848"><u>Conditional Formatting Module Overveiw</u></a><br />
<a href="https://www.devexpress.com/Support/Center/p/E1231">E1231</a><br />
<a href="http://documentation.devexpress.com/#Xaf/DevExpressExpressAppModuleBase_UpdateModeltopic"><u>ModuleBase.UpdateModel Method</u></a></p>

<br/>


