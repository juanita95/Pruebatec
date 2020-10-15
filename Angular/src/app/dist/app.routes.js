"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var body_component_1 = require("./body/body.component");
var cuerpo_component_1 = require("./cuerpo/cuerpo.component");
var facturas_component_1 = require("./facturas/facturas.component");
var routes = [
    { path: '', component: body_component_1.BodyComponent },
    { path: 'inicio', component: body_component_1.BodyComponent },
    { path: '¿Quienes somos?', component: cuerpo_component_1.CuerpoComponent },
    { path: 'facturas', component: facturas_component_1.FacturasComponent },
    { path: '**', component: body_component_1.BodyComponent },
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        core_1.NgModule({
            imports: [router_1.RouterModule.forRoot(routes)],
            exports: [router_1.RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
exports.AppRoutingModule = AppRoutingModule;

//# sourceMappingURL=app.routes.js.map
