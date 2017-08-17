
Imports System.IO
Imports Uyumsoft_API

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnSendInvoice_Click(sender As Object, e As EventArgs)
        Dim client As New IntegrationClient()
        client.Endpoint.Address = New ServiceModel.EndpointAddress("https://efatura-test.uyumsoft.com.tr/Services/Integration")
        client.ClientCredentials.UserName.UserName = "Uyumsoft"
        client.ClientCredentials.UserName.Password = "Uyumsoft"

        Dim data = New BinaryRequestData()

        Using stream As FileStream = File.OpenRead(Server.MapPath("~/e98b9f68-1b66-4c36-9dad-7fcc9c0fa5b4.zip"))
            Dim file As Byte() = New Byte(stream.Length - 1) {}
            stream.Read(file, 0, file.Length)
            data.Data = file
            Dim response = client.CompressedSendInvoice(data)

            Page.Response.Write("Sonuç :" & response.Message)

        End Using




    End Sub
End Class
