import { Routes } from "@angular/router";

import { DashboardComponent } from "../../pages/dashboard/dashboard.component";
import { IconsComponent } from "../../pages/icons/icons.component";
import { MapComponent } from "../../pages/map/map.component";
import { NotificationsComponent } from "../../pages/notifications/notifications.component";
import { UserComponent } from "../../pages/user/user.component";
import { TablesComponent } from "../../pages/tables/tables.component";
import { TypographyComponent } from "../../pages/typography/typography.component";
import { SendEmailComponent } from "src/app/pages/send-email/send-email.component";
// import { RtlComponent } from "../../pages/rtl/rtl.component";

export const AdminLayoutRoutes: Routes = [
  { path: "", redirectTo: "user" , pathMatch:"full"},
  // { path: "dashboard", component: DashboardComponent },
  // { path: "icons", component: IconsComponent },
  // { path: "maps", component: MapComponent },
  // { path: "notifications", component: NotificationsComponent },
  { path: "user", component: UserComponent },
  { path: "tables", component: TablesComponent },
  { path: "send-email", component: SendEmailComponent },
  // { path: "typography", component: TypographyComponent },
  // { path: "rtl", component: RtlComponent }
];
