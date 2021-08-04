import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { MainComponent } from './main/main.component';
import { CardComponent } from './card/card.component';
import { AboutComponent } from './about/about.component';
import { ServiceComponent } from './service/service.component';
import { HeadquarterComponent } from './headquarter/headquarter.component';
import { PartnersComponent } from './partners/partners.component';
import { EventComponent } from './event/event.component';
import { ContactsComponent } from './contacts/contacts.component';
import { CustomerPortalComponent } from './customer-portal/customer-portal.component';
import { OrderlistComponent } from './orderlist/orderlist.component';
import { NotificationComponent } from './notification/notification.component';
import { RegisterComponent } from './register/register.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { UrlLinkService } from './url-link.service';
import { RegistrationService } from './registration.service';
import { CustomerRegistrationComponent } from './customer-registration/customer-registration.component';
import { StaffManagmentComponent } from './staff-managment/staff-managment.component';
import {NgxPaginationModule} from 'ngx-pagination';
import { InqueryComponent } from './inquery/inquery.component';
import { LoginService } from './login.service';
import { InqueriesService } from './inqueries.service';
import { VendorComponent } from './vendor/vendor.component';
import { VendorService } from './vendor.service';
import { ClientComponent } from './client/client.component';
import { CustomerService } from './customer.service';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { ActionComponent } from './action/action.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MainComponent,
    CardComponent,
    AboutComponent,
    ServiceComponent,
    HeadquarterComponent,
    PartnersComponent,
    EventComponent,
    ContactsComponent,
    CustomerPortalComponent,
    OrderlistComponent,
    NotificationComponent,
    RegisterComponent,
    CustomerRegistrationComponent,
    StaffManagmentComponent,
    InqueryComponent,
    VendorComponent,
    ClientComponent,
    ActionComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    Ng2SearchPipeModule
  ],
  providers: [
    UrlLinkService,
    RegistrationService,
    LoginService,
    InqueriesService,
    VendorService,
    CustomerService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
