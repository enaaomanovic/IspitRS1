import { Component, Input, OnInit } from '@angular/core';

import {HttpClient, HttpHeaders} from "@angular/common/http";

import {Router} from "@angular/router";
import { MojConfig } from 'src/app/moj-config';
@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.css']
})
export class StudentEditComponent implements OnInit {
@Input() student:any;
opstina:any;
  constructor(private httpKlijent: HttpClient, private router: Router) { }


  GetOpstine() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Opstina/GetByAll", MojConfig.http_opcije()).subscribe(x=>{
      this.opstina = x;
    });
  }



  Spasi() :void
  {
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Student/Add",{
      "id":this.student.id,
      "ime":this.student.ime,
      "prezime":this.student.prezime,
      "opstina_rodjenja_id":this.student.opstina_rodjenja_id
    }, MojConfig.http_opcije()).subscribe(x=>{
      alert("Uspjesno dodan/uredjen student");
      location.reload();
    });
  }



Zatvori():void{
  location.reload();
}



  ngOnInit(): void {
    this.GetOpstine();
  }

}
