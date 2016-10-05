Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Online_PKM_DB.Models.Pokemon

Namespace Controllers
    Public Class CategoriesController
        Inherits System.Web.Mvc.Controller

        Private db As New PkmDBContext

        ' GET: Categories
        Function Index() As ActionResult
            Dim categories = db.Categories.Include(Function(c) c.EntityType)
            Return View(categories.ToList())
        End Function

        ' GET: Categories/Details/5
        Function Details(ByVal id As Guid?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim category As Category = db.Categories.Find(id)
            If IsNothing(category) Then
                Return HttpNotFound()
            End If
            Return View(category)
        End Function

        ' GET: Categories/Create
        Function Create() As ActionResult
            ViewBag.EntityTypeID = New SelectList(db.EntityTypes, "ID", "StandardCode")
            Return View()
        End Function

        ' POST: Categories/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,ParentCategoryID,SortOrder,OwnerID,IsSiteCategory,Name,Description,EntityTypeID,IsLocked,IsHidden")> ByVal category As Category) As ActionResult
            If ModelState.IsValid Then
                category.ID = Guid.NewGuid()
                db.Categories.Add(category)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.EntityTypeID = New SelectList(db.EntityTypes, "ID", "StandardCode", category.EntityTypeID)
            Return View(category)
        End Function

        ' GET: Categories/Edit/5
        Function Edit(ByVal id As Guid?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim category As Category = db.Categories.Find(id)
            If IsNothing(category) Then
                Return HttpNotFound()
            End If
            ViewBag.EntityTypeID = New SelectList(db.EntityTypes, "ID", "StandardCode", category.EntityTypeID)
            Return View(category)
        End Function

        ' POST: Categories/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,ParentCategoryID,SortOrder,OwnerID,IsSiteCategory,Name,Description,EntityTypeID,IsLocked,IsHidden")> ByVal category As Category) As ActionResult
            If ModelState.IsValid Then
                db.Entry(category).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.EntityTypeID = New SelectList(db.EntityTypes, "ID", "StandardCode", category.EntityTypeID)
            Return View(category)
        End Function

        ' GET: Categories/Delete/5
        Function Delete(ByVal id As Guid?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim category As Category = db.Categories.Find(id)
            If IsNothing(category) Then
                Return HttpNotFound()
            End If
            Return View(category)
        End Function

        ' POST: Categories/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Guid) As ActionResult
            Dim category As Category = db.Categories.Find(id)
            db.Categories.Remove(category)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
