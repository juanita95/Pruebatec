import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';


import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { BodyComponent } from './body/body.component';
import { FooterComponent } from './footer/footer.component';
import { AppRoutingModule } from './app.routes';
import { FacturasComponent } from './facturas/facturas.component';
import { CuerpoComponent } from './cuerpo/cuerpo.component';
import { HttpClientModule } from '@angular/common/http';
import { UsersService } from './services/users.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BodyComponent,
    FooterComponent,
    FacturasComponent,
    CuerpoComponent,

  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [UsersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
