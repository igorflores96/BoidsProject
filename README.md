# Steering Behaviors na Unity

Este projeto foi desenvolvido na Unity utilizando C# e implementa Steering Behaviors para movimentação autônoma de agentes no cenário.

## Funcionalidades

- Implementação dos Steering Behaviors:
  - Boids
  - Obstacle Avoidance
  - Seek and Flee
  - Wander
- Um script de suporte chamado `FreezeRotation`, que ajusta a posição dos objetos para manter o nome do objeto sempre visível, utilizando `FixedUpdate`.
- Estrutura organizada em pastas para cada comportamento e suas respectivas cenas.
- A cena `Boids` possui um `Manager` responsável por spawnar o prefab `BoidPrefab`.


## Desafios Encontrados

- Ajuste dos parâmetros de pesos nos boids para que suas movimentações parecessem realistas.

## Referências Utilizadas

- [Understanding Steering Behaviors: Seek](https://code.tutsplus.com/understanding-steering-behaviors-seek--gamedev-849t)
- [Craig Reynolds - Steering Behaviors](https://www.youtube.com/watch?v=bqtqltqcQhw)
- [Coding Adventure: Boids](https://www.youtube.com/watch?v=6dJlhv3hfQ0)
- [Steering Behaviors Implementation](https://www.youtube.com/watch?v=mjKINQigAE4&list=PL5KbKbJ6Gf99UlyIqzV1UpOzseyRn5H1d)

---

Clone este repositório para testar:

```bash
git clone https://github.com/igorflores96/BoidsProject.git


