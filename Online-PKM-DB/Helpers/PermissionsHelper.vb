Imports System.Security.Principal
Imports Microsoft.AspNet.Identity
Imports Online_PKM_DB.Models.Pokemon

Namespace Helpers
    Public Class PermissionsHelper
        ''' <summary>
        ''' Gets whether or not the given user is a moderator.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function IsModerator(user As IPrincipal) As Boolean
            Return user.IsInRole("PKMDB-Moderator")
        End Function

        ''' <summary>
        ''' Gets whether or not the current user can edit the access of the entity with the given ID
        ''' </summary>
        ''' <param name="entityID"></param>
        ''' <returns></returns>
        Public Shared Function CanEditEntityAccess(entityID As Guid, user As IPrincipal, context As PkmDBContext) As Boolean
            Return IsModerator(user) OrElse context.Entities.Where(Function(x) x.ID = entityID).First.UploaderUserID = user.Identity.GetUserId
        End Function
    End Class
End Namespace