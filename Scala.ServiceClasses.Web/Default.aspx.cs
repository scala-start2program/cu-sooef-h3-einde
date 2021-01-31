using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Scala.ServiceClasses.Core;

namespace Scala.ServiceClasses.Web
{
    public partial class Default : System.Web.UI.Page
    {
        static PersoonService persoonService;
        bool isNieuw;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                StartSituatie();
                ClearControls();
                persoonService = new PersoonService();
                VulListbox();

            }

        }
        private void StartSituatie()
        {
            grpPersonen.Disabled = false;
            grpDetails.Disabled = true;
            btnBewaren.Visible = false;
            btnAnnuleren.Visible = false;
        }
        private void BewerkSituatie()
        {
            grpPersonen.Disabled = true;
            grpDetails.Disabled = false;
            btnBewaren.Visible = true;
            btnAnnuleren.Visible = true;
        }
        private void ClearControls()
        {
            txtNaam.Text = "";
            txtVoornaam.Text = "";
            dtpGeboortedatum.SelectedDate = DateTime.MinValue;
            rdbMan.Checked = false;
            rdbVrouw.Checked = false;
            lblLeeftijd.Text = "";
        }
        private void VulListbox()
        {
            lstPersonen.DataSource = persoonService.Personen;
            lstPersonen.DataBind();
        }
        protected void lstPersonen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPersonen.SelectedIndex == -1)
                return;
            Persoon persoon = persoonService.Personen[lstPersonen.SelectedIndex];
            txtNaam.Text = persoon.Naam;
            txtVoornaam.Text = persoon.Voornaam;
            dtpGeboortedatum.SelectedDate = persoon.Geboortedatum;
            dtpGeboortedatum.VisibleDate = persoon.Geboortedatum;
            rdbMan.Checked = rdbVrouw.Checked = false;
            if (persoon.IsMan)
                rdbMan.Checked = true;
            else
                rdbVrouw.Checked = true;
            lblLeeftijd.Text = persoon.GetLeeftijd();
        }

        protected void btnNieuw_Click(object sender, EventArgs e)
        {
            isNieuw = true;
            ClearControls();
            BewerkSituatie();
            txtNaam.Focus();
        }

        protected void btnWijzig_Click(object sender, EventArgs e)
        {
            if (lstPersonen.SelectedItem == null)
                return;

            isNieuw = false;
            BewerkSituatie();
            txtNaam.Focus();
        }

        protected void btnWis_Click(object sender, EventArgs e)
        {
            if (lstPersonen.SelectedItem == null)
                return;

            Persoon persoon = persoonService.Personen[lstPersonen.SelectedIndex];
            persoonService.VerwijderPersoon(persoon);
            VulListbox();
        }

        protected void btnBewaren_Click(object sender, EventArgs e)
        {
            string naam = txtNaam.Text.Trim();
            if (naam.Length == 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Gelieve een naam op te geven');", true);
                txtNaam.Focus();
                return;
            }
            string voornaam = txtVoornaam.Text.Trim();
            if (voornaam.Length == 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Gelieve een voornaam op te geven');", true);
                txtVoornaam.Focus();
                return;
            }
            if (dtpGeboortedatum.SelectedDate == null || dtpGeboortedatum.SelectedDate == DateTime.MinValue)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Gelieve een geboortedatum op te geven');", true);
                dtpGeboortedatum.Focus();
                return;
            }
            DateTime geboortedatum = (DateTime)dtpGeboortedatum.SelectedDate;
            if (rdbMan.Checked == false && rdbVrouw.Checked == false)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Gelieve een geslacht te kiezen');", true);
                rdbMan.Focus();
                return;
            }
            bool isman = false;
            if (rdbMan.Checked == true)
            {
                isman = true;
            }
            Persoon persoon;
            if (isNieuw)
            {
                persoon = new Persoon(naam, voornaam, geboortedatum, isman);
                persoonService.VoegPersoonToe(persoon);
            }
            else
            {
                persoon = persoonService.Personen[lstPersonen.SelectedIndex];
                persoon.Naam = naam;
                persoon.Voornaam = voornaam;
                persoon.Geboortedatum = geboortedatum;
                persoon.IsMan = isman;
                persoonService.OrderList();
            }
            StartSituatie();
            VulListbox();
            int teller = 0;
            int positie = -1;
            foreach(Persoon zoekpersoon in persoonService.Personen)
            {
                if (zoekpersoon == persoon)
                {
                    positie = teller;
                    break;
                }
                teller++;
            }
            lstPersonen.SelectedIndex = positie;
            lstPersonen_SelectedIndexChanged(null, null);

        }

        protected void btnAnnuleren_Click(object sender, EventArgs e)
        {
            StartSituatie();
            ClearControls();
            if (lstPersonen.SelectedIndex > -1)
                lstPersonen_SelectedIndexChanged(null, null);
        }
    }
}