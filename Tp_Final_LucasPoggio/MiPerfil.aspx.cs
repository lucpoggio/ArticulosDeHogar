﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Tp_Final_LucasPoggio
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((User)Session["User"] != null && ((User)Session["User"]).Admin)
                txtEmail.Enabled = true;

            if (!Seguridad.sesionActiva(Session["User"]))
                Response.Redirect("Login.aspx", false);
            else {

                if (!IsPostBack) {
                    User user = (User)Session["User"];
                    txtNombre.Text = user.Nombre;
                    txtApellido.Text = user.Apellido;
                    txtEmail.Text = user.Email;
                    txtPass.TextMode = TextBoxMode.SingleLine;
                    txtPass.Text = user.Pass;
                    if (user.Admin)
                        chkSi.Checked = true;
                    else
                        chkNo.Checked = true;
                    if(!string.IsNullOrEmpty(user.UrlImagenPerfil))
                        imgNuevoPerfil.ImageUrl = "~/Images/" + user.UrlImagenPerfil;
                }

            }
        }

        //Modifica datos del perfil
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Validaciones())
                    return;

                string ruta = Server.MapPath("./Images/");
                UserNegocio negocio = new UserNegocio();
                User usuarioLogueado = new User();

                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + ((User)Session["User"]).Email + ".png");
                
                usuarioLogueado.UrlImagenPerfil = "perfil-" + ((User)Session["User"]).Email + ".png";

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + usuarioLogueado.UrlImagenPerfil;

                usuarioLogueado.Nombre = txtNombre.Text;
                usuarioLogueado.Email = txtEmail.Text;
                usuarioLogueado.Pass = txtPass.Text;
                usuarioLogueado.Apellido = txtApellido.Text;

                if(((User)Session["User"]).Admin)
                    usuarioLogueado.Admin = true;
                else
                    usuarioLogueado.Admin = false;

                usuarioLogueado.id = ((User)Session["User"]).id;
                negocio.ModificarUsuario(usuarioLogueado);
                Session.Add("User", usuarioLogueado);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                throw;
            }
         
        }

        //Agrega un nuevo usuario
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            UserNegocio negocio = new UserNegocio();
            User nuevoUsuario = new User();

            Page.Validate();
            if (!Page.IsValid)
                return;

            if (Validaciones() || ValidarMail() || ValidarCheck())
                return;
            else {

                string ruta = Server.MapPath("./Images/");
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + txtEmail.Text + ".png");

                nuevoUsuario.UrlImagenPerfil = "perfil-" + txtEmail.Text + ".png";
                nuevoUsuario.Email = txtEmail.Text;
                nuevoUsuario.Pass = txtPass.Text;
                nuevoUsuario.Nombre = txtNombre.Text;
                nuevoUsuario.Apellido = txtApellido.Text;
                if (chkSi.Checked)
                    nuevoUsuario.Admin = true;
                else
                    nuevoUsuario.Admin = false;

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + nuevoUsuario.UrlImagenPerfil;

                negocio.AgregarUsuario(nuevoUsuario);
            }         
        }

        //Validaciones backEnd de los campos del formulario
        private bool Validaciones()
        {
            UserNegocio negocio = new UserNegocio();
            bool bandera = false;
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtEmail.Text == "")
            {
                string script = "alert('Campo requerido!')";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                return bandera = true;
            }
            else
            {
                if (txtNombre.Text.Any(char.IsDigit) || txtApellido.Text.Any(char.IsDigit)) { 
                    string script = "alert('Solo letras!')";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                    return bandera = true;
                }
            }
            return bandera;
        }

        //Valida que no haya emails repetidos y que cumplan con el formato requerido
        private bool ValidarMail() {
            UserNegocio negocio = new UserNegocio();
            bool bandera = false;
            if (negocio.ValidarUsuario(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                string script = "alert('Email incorrecto o utilizado por otro usuario!')";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                return bandera = true;
            }
            if (txtPass.Text == "")
            {
                string script = "alert('Password requerido!')";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                return bandera = true;
            }
            return bandera;
        }
        //Valida que el usuario elija un check
        private bool ValidarCheck() {
            UserNegocio negocio = new UserNegocio();
            bool bandera = false;
            if (!chkSi.Checked && !chkNo.Checked)
            {
                string script = "alert('Seleccione si el nuevo usuario es admin o no!')";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                return bandera = true;
            }
            return bandera;
        }

    }
}