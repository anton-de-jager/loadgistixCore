using loadgistix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace loadgistix.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class NavigationController : ControllerBase
    {
        private readonly loadgistixContext _context;

        public NavigationController(loadgistixContext context)
        {
            _context = context;
        }

        // GET: api/Navigation
        [HttpGet]
        public async Task<ActionResult<NavigationResult>> GetNavigation()
        {
            List<Navigation> result = new List<Navigation>();
            NavigationResult resultGroup = new NavigationResult();
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                Guid userId = identity.Claims.Where(x => x.Type == "Id").Count() > 0 ? Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value) : Guid.Empty;
                User user = await _context.User.Where(x => x.Id == userId).Include(x => x.UserPermission).ThenInclude(y => y.Permission).FirstOrDefaultAsync();

                Navigation navigationAdminGroup = new Navigation();
                navigationAdminGroup.Children = new List<Navigation>();
                Navigation navigationLookups = new Navigation();
                Navigation navigationDashboard = new Navigation();

                Navigation navigationFleetGroup = new Navigation();
                navigationFleetGroup.Children = new List<Navigation>();
                Navigation navigationVehicles = new Navigation();
                Navigation navigationDrivers = new Navigation();

                Navigation navigationLoadsGroup = new Navigation();
                navigationLoadsGroup.Children = new List<Navigation>();
                Navigation navigationMyLoads = new Navigation();
                Navigation navigationLoadsAvailable = new Navigation();

                Navigation navigationBidsGroup = new Navigation();
                navigationBidsGroup.Children = new List<Navigation>();
                Navigation navigationBids = new Navigation();

                Navigation navigationAdvertsGroup = new Navigation();
                navigationAdvertsGroup.Children = new List<Navigation>();
                Navigation navigationAdverts = new Navigation();

                Navigation navigationDirectoryGroup = new Navigation();
                navigationDirectoryGroup.Children = new List<Navigation>();
                Navigation navigationBusinessDirectory = new Navigation();
                Navigation navigationMyDirectory = new Navigation();

                Navigation navigationResourcingGroup = new Navigation();
                navigationResourcingGroup.Children = new List<Navigation>();
                Navigation navigationClients = new Navigation();
                Navigation navigationProspects = new Navigation();
                Navigation navigationStatementOfWork = new Navigation();
                Navigation navigationTimesheet = new Navigation();
                Navigation navigationInvoice = new Navigation();

                if (user.UserPermission.Where(x => x.Permission.Description == "dashboard").Count() > 0)
                {
                    navigationDashboard.Id = "dashboard";
                    navigationDashboard.Title = "Dashboard";
                    navigationDashboard.Type = "basic";
                    navigationDashboard.Icon = "heroicons_outline:chart-pie";
                    navigationDashboard.Link = "/dashboard";
                    result.Add(navigationDashboard);
                }

                if (user.UserPermission.Where(x => x.Permission.Description == "admin").Count() > 0)
                {
                    navigationLookups.Id = "admin-lookups";
                    navigationLookups.Title = "Lookups";
                    navigationLookups.Type = "basic";
                    navigationLookups.Icon = "heroicons_outline:chart-pie";
                    navigationLookups.Link = "/lookups";
                    navigationAdminGroup.Children.Add(navigationLookups);
                }

                if (user.UserPermission.Where(x => x.Permission.Description == "admin").Count() > 0)
                {
                    navigationAdminGroup.Id = "admin";
                    navigationAdminGroup.Title = "Admin";
                    navigationAdminGroup.Type = "group";
                    navigationAdminGroup.Icon = "heroicons_outline:chart-pie";
                    result.Add(navigationAdminGroup);
                }

                if (user.UserPermission.Where(x => x.Permission.Description == "vehicles").Count() > 0)
                {
                    navigationVehicles.Id = "fleet-vehicles";
                    navigationVehicles.Title = "My Vehicles";
                    navigationVehicles.Type = "basic";
                    navigationVehicles.Icon = "iconsmind:truck";
                    navigationVehicles.Link = "/vehicles";
                    navigationFleetGroup.Children.Add(navigationVehicles);
                }

                if (user.UserPermission.Where(x => x.Permission.Description == "drivers").Count() > 0)
                {
                    navigationDrivers.Id = "fleet-drivers";
                    navigationDrivers.Title = "My Drivers";
                    navigationDrivers.Type = "basic";
                    navigationDrivers.Icon = "mat_outline:people";
                    navigationDrivers.Link = "/drivers";
                    navigationFleetGroup.Children.Add(navigationDrivers);
                }

                if (user.UserPermission.Where(x => x.Permission.Description == "vehicles" || x.Permission.Description == "drivers").Count() > 0)
                {
                    navigationFleetGroup.Id = "fleet";
                    navigationFleetGroup.Title = "Fleet";
                    navigationFleetGroup.Type = "group";
                    navigationFleetGroup.Icon = "iconsmind:truck";
                    result.Add(navigationFleetGroup);
                }

                if (user.UserPermission.Where(x => x.Permission.Description == "loads").Count() > 0)
                {
                    navigationMyLoads.Id = "loads-loads";
                    navigationMyLoads.Title = "My Loads";
                    navigationMyLoads.Type = "basic";
                    navigationMyLoads.Icon = "mat_outline:people";
                    navigationMyLoads.Link = "/loads";
                    navigationLoadsGroup.Children.Add(navigationMyLoads);
                }

                if (user.UserPermission.Where(x => x.Permission.Description == "vehicles").Count() > 0)
                {
                    navigationLoadsAvailable.Id = "loads-available";
                    navigationLoadsAvailable.Title = "Available Loads";
                    navigationLoadsAvailable.Type = "basic";
                    navigationLoadsAvailable.Icon = "mat_outline:people";
                    navigationLoadsAvailable.Link = "/loads-available";
                    navigationLoadsGroup.Children.Add(navigationLoadsAvailable);
                }

                if (user.UserPermission.Where(x => x.Permission.Description == "loads" || x.Permission.Description == "vehicles").Count() > 0)
                {
                    navigationLoadsGroup.Id = "loads";
                    navigationLoadsGroup.Title = "Loads";
                    navigationLoadsGroup.Type = "group";
                    navigationLoadsGroup.Icon = "heroicons_outline:chart-pie";
                    result.Add(navigationLoadsGroup);
                }

                if (user.UserPermission.Where(x => x.Permission.Description == "vehicles").Count() > 0)
                {
                    navigationBids.Id = "bids-bids";
                    navigationBids.Title = "My Bids";
                    navigationBids.Type = "basic";
                    navigationBids.Icon = "iconsmind:mail_money";
                    navigationBids.Link = "/bids";
                    navigationBidsGroup.Children.Add(navigationBids);

                    navigationBidsGroup.Id = "bids";
                    navigationBidsGroup.Title = "Bids";
                    navigationBidsGroup.Type = "group";
                    navigationBidsGroup.Icon = "iconsmind:mail_money";
                    result.Add(navigationBidsGroup);
                }

                if (user.UserPermission.Where(x => x.Permission.Description == "adverts").Count() > 0)
                {
                    navigationAdverts.Id = "adverts-adverts";
                    navigationAdverts.Title = "My Adverts";
                    navigationAdverts.Type = "basic";
                    navigationAdverts.Icon = "iconsmind:mail_money";
                    navigationAdverts.Link = "/adverts";
                    navigationAdvertsGroup.Children.Add(navigationAdverts);

                    navigationAdvertsGroup.Id = "adverts";
                    navigationAdvertsGroup.Title = "Adverts";
                    navigationAdvertsGroup.Type = "group";
                    navigationAdvertsGroup.Icon = "iconsmind:mail_money";
                    result.Add(navigationAdvertsGroup);
                }

                if (user.UserPermission.Where(x => x.Permission.Description == "directory").Count() > 0)
                {
                    navigationMyDirectory.Id = "directory-directory";
                    navigationMyDirectory.Title = "My Directory Entries";
                    navigationMyDirectory.Type = "basic";
                    navigationMyDirectory.Icon = "iconsmind:mail_money";
                    navigationMyDirectory.Link = "/directory";
                    navigationDirectoryGroup.Children.Add(navigationMyDirectory);
                }

                navigationBusinessDirectory.Id = "business-directory";
                navigationBusinessDirectory.Title = "Business Directory";
                navigationBusinessDirectory.Type = "basic";
                navigationBusinessDirectory.Icon = "iconsmind:mail_money";
                navigationBusinessDirectory.Link = "/business-directory";
                navigationDirectoryGroup.Children.Add(navigationBusinessDirectory);

                navigationDirectoryGroup.Id = "directory";
                navigationDirectoryGroup.Title = "Directory";
                navigationDirectoryGroup.Type = "group";
                navigationDirectoryGroup.Icon = "heroicons_outline:chart-pie";
                result.Add(navigationDirectoryGroup);

                //if (user.UserPermission.Where(x => x.Permission.Description == "resourcing").Count() > 0)
                //{
                //    navigationClients.Id = "resourcing-clients";
                //    navigationClients.Title = "Clients";
                //    navigationClients.Type = "basic";
                //    navigationClients.Icon = "heroicons_outline:library";
                //    navigationClients.Link = "/clients";
                //    navigationResourcingGroup.Children.Add(navigationClients);

                //    navigationProspects.Id = "resourcing-prospects";
                //    navigationProspects.Title = "Prospects";
                //    navigationProspects.Type = "basic";
                //    navigationProspects.Icon = "heroicons_outline:users";
                //    navigationProspects.Link = "/prospects";
                //    navigationResourcingGroup.Children.Add(navigationProspects);

                //    navigationStatementOfWork.Id = "resourcing-sow";
                //    navigationStatementOfWork.Title = "Statement Of Work";
                //    navigationStatementOfWork.Type = "basic";
                //    navigationStatementOfWork.Icon = "heroicons_outline:book-open";
                //    navigationStatementOfWork.Link = "/sow";
                //    navigationResourcingGroup.Children.Add(navigationStatementOfWork);

                //    navigationTimesheet.Id = "resourcing-timesheet";
                //    navigationTimesheet.Title = "Timesheet";
                //    navigationTimesheet.Type = "basic";
                //    navigationTimesheet.Icon = "heroicons_outline:clipboard-list";
                //    navigationTimesheet.Link = "/timesheet";
                //    navigationResourcingGroup.Children.Add(navigationTimesheet);

                //    navigationInvoice.Id = "resourcing-invoice";
                //    navigationInvoice.Title = "Invoice";
                //    navigationInvoice.Type = "basic";
                //    navigationInvoice.Icon = "heroicons_outline:document-report";
                //    navigationInvoice.Link = "/invoice";
                //    navigationResourcingGroup.Children.Add(navigationInvoice);

                //    navigationResourcingGroup.Id = "resourcing";
                //    navigationResourcingGroup.Title = "Resourcing";
                //    navigationResourcingGroup.Type = "group";
                //    navigationResourcingGroup.Icon = "heroicons_outline:folder-open";
                //    result.Add(navigationResourcingGroup);
                //}

                resultGroup.Default = result;
                resultGroup.Compact = result;
                resultGroup.Futuristic = result;
                resultGroup.Horizontal = result;
            }
            catch (Exception exception)
            {
                //TODO: Logger.Error
            }
            return resultGroup;
        }
    }
}