import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { ContactsComponent } from './contacts/contacts.component';
import { CustomerPortalComponent } from './customer-portal/customer-portal.component';
import { CustomerRegistrationComponent } from './customer-registration/customer-registration.component';
import { EventComponent } from './event/event.component';
import { HeadquarterComponent } from './headquarter/headquarter.component';
import { HomeComponent } from './home/home.component';
import { InqueryComponent } from './inquery/inquery.component';
import { MainComponent } from './main/main.component';
import { NotificationComponent } from './notification/notification.component';
import { OrderlistComponent } from './orderlist/orderlist.component';
import { PartnersComponent } from './partners/partners.component';
import { RegisterComponent } from './register/register.component';
import { ServiceComponent } from './service/service.component';
import { StaffManagmentComponent } from './staff-managment/staff-managment.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      { path: '', component: MainComponent },
      { path: 'about', component: AboutComponent },
      { path: 'services', component: ServiceComponent },
      { path: 'head-quarters', component: HeadquarterComponent },
      { path: 'partner', component: PartnersComponent },
      { path: 'event', component: EventComponent },
      { path: 'contacts', component: ContactsComponent },
      {path:"register",component:RegisterComponent}
    ],
  },
  {
    path: 'portal',
    component: CustomerPortalComponent,
    children:[
      {path:"",component:OrderlistComponent},
      {path:"notification",component:NotificationComponent},
      {path:"customer-reg",component:CustomerRegistrationComponent},
      {path:"staff-managment",component:StaffManagmentComponent},
      {path:"inquery",component:InqueryComponent}
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
