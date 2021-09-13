export interface ILogin {
  email: string;
  password: string;
}

export interface ICheckUser {
  userName: string;
  email: string;
}

export interface IRegisterUser {
  userName: string;
  email: string;
  firstName: string;
  lastName: string;
  password: string;
}

export interface IUpdateUser {
  firstName: string;
  lastName: string;
}
