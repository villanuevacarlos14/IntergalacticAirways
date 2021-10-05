import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { Starship } from 'src/app/model/starship';
import { StarshipService } from 'src/app/service/starship.service';

@Component({
  selector: 'app-starship-search',
  templateUrl: './starship-search.component.html',
  styleUrls: ['./starship-search.component.scss']
})
export class StarshipSearchComponent implements OnInit {

  starships: Starship[] = [];
  loading: boolean = false;
  formGroup: FormGroup = this.fb.group({search: []});
  constructor(private starshipService: StarshipService, private fb: FormBuilder) { 
 
  }

  ngOnInit(): void {
  }

  onSubmit(): void{
    this.loading = true;
    this.starshipService.search(this.formGroup?.controls['search'].value).subscribe((data)=>{
      this.starships = data;
      this.loading = false;
    }, (error=>{
      this.loading = false;
    }));
  }
}
