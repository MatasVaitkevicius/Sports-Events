import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {ICheckUser, IRegisterUser} from '../shared/login.model';
import {UserService} from '../shared/user.service';
import {ToastrService} from 'toastr-ng2';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  private exists: boolean;
  public error = false;
  public passwordError = false;
  public mouseoverLogin = true;
  public username: string;
  public email: string;
  public firstname: string;
  public lastname: string;
  public password: string;
  public cpassword: string;

  constructor(private userService: UserService, private router: Router, private toastrService: ToastrService) {
  }

  ngOnInit() {
  }

  register(formValues) {
    const checkUser: ICheckUser = {
      email: formValues.email,
      userName: formValues.username
    };

    this.userService.checkUser(checkUser).subscribe(r => {
      this.exists = r;
      this.error = false;
      this.passwordError = false;
      if (formValues.password !== formValues.cpassword && this.exists) {
        this.error = true;
        this.passwordError = true;
      } else if (formValues.password !== formValues.cpassword) {
          this.passwordError = true;
      } else if (this.exists) {
        this.error = true;
      } else {
        this.error = false;
        this.passwordError = false;
        const register: IRegisterUser = {
          email: formValues.email,
          password: formValues.password,
          userName: formValues.username,
          firstName: formValues.firstname,
          lastName: formValues.lastname
        };
        this.userService.registerUser(register).subscribe();

        this.toastrService.success('User registered!', 'Registered', {timeOut: 1500});

        this.router.navigate(['events']);
      }
    });
  }

  cancel() {
    this.router.navigate(['events']);
  }
}
