@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@If Not My.User.IsAuthenticated Then
    @<p><b>Note: you are not logged in.  If you proceed to upload this Pokémon, you will be unable to modify or delete it (when these features are available).</b></p>
End If

@Using (Html.BeginForm("Create", "Pokemon", FormMethod.Post, New With {.enctype = "multipart/form-data"}))
   @<input type = "file" name="file" id="file" />
   @<input type = "submit" value="Upload" Class="save" id="btnid" />
End Using