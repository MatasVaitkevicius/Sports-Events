import {Pipe, PipeTransform} from '@angular/core';

@Pipe({name: 'stringToDate'})
export class StringToDatePipe implements PipeTransform {

  constructor() {
  }

  transform(value: string): Date {
    return new Date(value);
  }
}
