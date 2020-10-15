"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
var UsersService = /** @class */ (function () {
    function UsersService(http) {
        this.http = http;
    }
    UsersService.prototype.getUserName = function () {
        var _this = this;
        return this.http
            .get('https://localhost:5001/api/users/getall')
            .toPromise()
            .then(function (res) { return (_this.list = res); });
    };
    UsersService.prototype.send = function (id) {
        var myheader = new http_1.HttpHeaders().set('Content-Type', 'application/json; charset=UTF-8');
        this.http
            .put('https://localhost:5001/api/users/update/' + id, {
            headers: myheader
        })
            .toPromise()
            .then(function (res) {
            location.reload();
        })["catch"](function (err) { });
    };
    UsersService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], UsersService);
    return UsersService;
}());
exports.UsersService = UsersService;

//# sourceMappingURL=users.service.js.map
