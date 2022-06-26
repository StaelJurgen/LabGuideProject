## comment on proposition

Zoals al vie mail bevestigd zou ik ook voor optie 1 opteren in jouw plaats, lijkt mij een interessant project en je hebt een extra motivatie dat het wie weet ooi op de werkvloer kan gebruikt worden..
Bekijk wel nog eens je database ontwikkeling, volgens mij kan je hier en daar, in functie van latere uitbreiding, best nog een opsplitsing in gerelateerde entities gebruiken...? (bv. een aparte entity voor storage conditions...?)
Maar voor de rest lijkt dit een prima project!

## propositions

Voorstel 1 (voorkeur): creatie view labogids        Web based application or API possible
- Mogelijke entities
    - Properties (bepalingen)
        - Name (e.g. TSH)
        - Synonyms (e.g. thyroid stimulating hormone)
        - Sample Types (blood, urine)
        - Stability (e.g. 120h)
        - Storage conditions (e.g. freezer, fridge, room temperature)
        - Volume
        - Executive lab (e.g. UZ Leuven, St.-Lucas)
        - Request definition (e.g. A_TSH)
        - Closed period (e.g. 10d between two requests)
        - TAT (turnaround time, e.g. 1h)
        - References (e.g. 40 - 100 mg/dL)

    - Request definition (aanvraagdefinities)
        - Name (e.g. A_TSH)
        - Billing code (e.g. 540154)
        - Diagnosis rule
        - Cumulation rule

    - Sample types
        - Name
        - Picture (sample tube)

    - Executing laboratory
        - Name
        - Address
        - Link to lab site


Voorstel 2: creatie programma Rode Kruis            WPF-applicatie or API possible
- Mogelijke entities
    - Courses
        - Name
        - Teachers
        - Simulants
        - Students
        - Price
        - Discount
        - Modules
        - Locations

    - Modules
        - Name
        - Duration
        - Necessities (nr. of teachers, nr of simulants)
    
    - Teachers
        - Name
        - Firstname
        - Competencies (not all teachers may give all courses)
        - Availability

    - Simulants
        - See teachers

    - Locations
        - Name
        - Address
        - Room
        - Accessories
