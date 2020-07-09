import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AppComponent, Message, MesType, Captcha} from './app.component';
import {User} from './app.component';
import {NgForm} from '@angular/forms';
import {HttpParams} from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private http: HttpClient) {
  }

  getMessageTypes() {
    return this.http.get<MesType[]>('https://localhost:44376/api/mestype');
  }

  setUser(user: NgForm) {
    const sendUser = {name: user.value.name, email: user.value.email, phoneNumber: user.value.phoneNumber};

    return this.http.post('https://localhost:44376/api/users', sendUser);
  }

  setMessage(message: NgForm, user: User) {
    const sendMessage: Message = {userId: user.id, mesTypeId: Number(message.value.mesType), userMessage: message.value.userMessage};
    return this.http.post('https://localhost:44376/api/messages', sendMessage);
  }

  getImage() {
    return this.http.get('https://localhost:44376/api/captcha', {responseType: 'text'});
  }

  setCaptchaKey(Key: NgForm) {
    const sendKey = {key: Key.value.captchaKey};
    return this.http.post('https://localhost:44376/api/captcha', sendKey);
  }
}
