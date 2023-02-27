import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {
  id:any;
  student:any={};
  noviSemestar:any;
  akademske:any;
  upis:any;
  ovjera:any

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {}


  GetStudent() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetById?studentId="+this.id, MojConfig.http_opcije()).subscribe(x=>{
      this.student = x;
    });
  }
  GetAkademske() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/AkademskeGodine/GetAll_ForCmb", MojConfig.http_opcije()).subscribe(x=>{
      this.akademske = x;
    });
  }
  GetUpisi() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/MaticnaControlers/GettAll?studentId="+this.id, MojConfig.http_opcije()).subscribe(x=>{
      this.upis = x;
    });
  }

  Spasi() :void
  {
    this.noviSemestar.studentId=this.student.id;
    this.httpKlijent.post(MojConfig.adresa_servera+ "/MaticnaControlers/Add",this.noviSemestar,
     MojConfig.http_opcije()).subscribe({next:x=>{
    porukaSuccess("uspjesno dodana godina");
    location.reload();
    },error:err=>porukaError(err.error)});
  }
  Spasi2() :void
  {
    
    this.httpKlijent.post(MojConfig.adresa_servera+ "/MaticnaControlers/Ovjeri",this.ovjera,
     MojConfig.http_opcije()).subscribe({next:x=>{
    porukaSuccess("uspjesno ovjerena godina");
    location.reload();
    },error:err=>porukaError(err.error)});
  }
Zatvori():void{
  this.noviSemestar=null;
}
Zatvori2():void{
  this.ovjera=null;
}

Otvori(id:any):void{
  this.ovjera={id:id,datumOvjere:new Date().toISOString().slice(0,10)}
}

  ngOnInit(): void {
    this.id=this.route.snapshot.paramMap.get('id');
    this.GetStudent();
    this.GetAkademske();
    this.GetUpisi();
  }
}
