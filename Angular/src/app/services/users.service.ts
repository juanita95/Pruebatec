import { Injectable } from '@angular/core';
import { Users } from '../models/users';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  list: Users[];

  constructor(private http: HttpClient) {}
  getUserName() {
    return this.http
      .get('https://localhost:5001/api/users/getall')
      .toPromise()
      .then((res) => (this.list = res as Users[]));
  }
  send(id) {
    const myheader = new HttpHeaders().set(
      'Content-Type',
      'application/json; charset=UTF-8'
    );

    this.http
      .put(
        'https://localhost:5001/api/users/update/' + id,

        {
          headers: myheader,
        }
      )
      .toPromise()
      .then((res) => {
        location.reload();
      })
      .catch((err) => {});
  }
}
