import {Component, OnInit} from '@angular/core';
import {NgForm} from '@angular/forms';
import {HttpService} from './http.service';
import {error} from '@angular/compiler/src/util';

export class User {
  id: number;
  name: string;
  email: string;
  phoneNumber: string;
}

export class MesType {
  id: number;
  messageType: string;
}

export class Message {
  userId: number;
  mesTypeId: number;
  userMessage: string;
}

export class Captcha {
  key: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [HttpService]
})

export class AppComponent implements OnInit {
  type: MesType = new MesType();
  mesTypes: MesType[] = [];
  receivedUser: User;
  receivedMes: Message;
  done: boolean = false;
  keyValid: boolean = true;
  image: string = 'data:image/png;base64,';
  mask = ['+', '7', ' ', '(', /[1-9]/, /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, '-', /\d/, /\d/, '-', /\d/, /\d/];

  constructor(private httpService: HttpService) {
  }

  ngOnInit() {
    this.httpService.getImage().subscribe(data => {
      this.image += data;
    }, error => console.log(error));
    this.httpService.getMessageTypes().subscribe(data => this.mesTypes = data);
  }

  submit(form: NgForm) {
    this.httpService.setCaptchaKey(form).subscribe(data => {
        this.keyValid = true;
        this.httpService.setUser(form).subscribe((data: User) => {
            this.receivedUser = data;
            console.log(this.receivedUser);
            this.httpService.setMessage(form, this.receivedUser).subscribe((data: Message) => {
                this.receivedMes = data;
                console.log(this.receivedMes);
                this.done = true;
              },
              error => console.log(error));
          },
          error => console.log(error));
      },
      error => {
        console.log(error);
        this.keyValid = false;
      });
  }

  reload() {
    window.location.reload();
  }

  reCaptcha() {
    this.image = 'data:image/png;base64,';
    this.httpService.getImage().subscribe(data => {
      this.image += data;
    }, error => console.log(error));
  }
}
