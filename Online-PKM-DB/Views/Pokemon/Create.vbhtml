@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm("Create", "Pokemon", FormMethod.Post, New With {.enctype = "multipart/form-data"}))
   @<input type = "file" name="file" id="file" />
   @<input type = "submit" value="Upload" Class="save" id="btnid" />
End Using