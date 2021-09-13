import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../shared/auth.service';
import {Router} from '@angular/router';
import {ToastrService} from 'toastr-ng2';
import {UserService} from '../shared/user.service';
import {IUpdateUser} from '../shared/login.model';

@Component({
  selector: 'app-profile',
  templateUrl: 'profile.component.html',
  styleUrls: ['profile.component.css']
})
export class ProfileComponent implements OnInit {
  profileForm: FormGroup;
  private firstName: FormControl;
  private lastName: FormControl;

  constructor(private authService: AuthService,
              private userService: UserService,
              private router: Router,
              private toastrService: ToastrService) {
  }

  ngOnInit(): void {
    this.firstName = new FormControl(
      this.authService.currentUser.firstName, [Validators.required,
        Validators.pattern('[a-zA-Z].*')]);
    this.lastName = new FormControl(
      this.authService.currentUser.lastName, Validators.required);
    this.profileForm = new FormGroup({
      firstName: this.firstName,
      lastName: this.lastName
    });
  }

  saveProfile(formValue) {
    const userUpdate: IUpdateUser = {
      firstName: formValue.firstName,
      lastName: formValue.lastName
    };

    if (this.profileForm.valid) {
      this.userService.updateUser(this.authService.currentUser.userId, userUpdate).subscribe();
      this.toastrService.success('Profile saved!', 'Saved', {timeOut: 1500});
      this.authService.updateUser(formValue.firstName, formValue.lastName);
      this.router.navigate(['events']);
    }
  }

  validateFirstName() {
    return this.firstName.valid || this.firstName.untouched;
  }


  validateLastName() {
    return this.lastName.valid || this.lastName.untouched;
  }

  cancel() {
    this.router.navigate(['events']);
  }
}
