import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { BodyComponent } from './body/body.component';
import { CuerpoComponent } from './cuerpo/cuerpo.component';
import { FacturasComponent } from './facturas/facturas.component';


const routes: Routes = [
  { path: '', component: BodyComponent },
  { path: 'inicio', component: BodyComponent },
  { path: '¿Quienes somos?', component: CuerpoComponent },
  { path: 'facturas', component: FacturasComponent },
  { path: '**', component: BodyComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
