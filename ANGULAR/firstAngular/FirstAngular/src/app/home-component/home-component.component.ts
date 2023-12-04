import { Component, Inject } from '@angular/core';
import { Employee } from './models/Employee';

@Component({
  selector: 'app-home-component',
  templateUrl: './home-component.component.html',
  styleUrls: ['./home-component.component.css'],
})



export class HomeComponentComponent {
  name = 'salil';
  alive: boolean = true;
  gender: string = 'male';
  gotValue:string = "";

  twoWay:string = '';

  numbers = [1, 2, 3, 4, 5];

  persons = [
    {
      name: 'Salil',
      age: 23,
    },
    {
      name: 'Achal',
      age: 21,
    },
  ];


  employees : Employee[] = []
  
  recieveValue(inpVal:string){
    this.gotValue = "Hello " + inpVal
  }

  recieveEmployee(name: string, age : number, department : string){
    
    let newEmp = new Employee(name, age, department);
    this.employees.push(newEmp);
    console.log(this.employees)
  }

}
