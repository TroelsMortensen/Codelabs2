# Choosing Representative Values

After identifying partitions, choose one representative value from each partition.

## Representative Value Rule

Pick one (or a few) value(s) that is clearly inside each partition.

For EP specifically, avoid focusing on boundaries here. Boundary-focused values belong primarily to Boundary Value Analysis (BVA).

## Example Table (Score 0..100)

| Partition | Representative | Expected |
|----------|----------------|----------|
| `score < 0` | `-5`  | reject |
| `0..100`    | `50`  | accept |
| `score > 100` | `150` | reject |

## Why This Works

Each representative stands for one partition. If the representative behaves as expected, it increases confidence that the partition behavior is implemented correctly.

## ASCII Mini Visual

```text
Partitions:     [ invalid ]   [ valid ]   [ invalid ]
Values:             -5           50          150
```

## EP and BVA

- **EP** chooses partitions and one value per partition.
- **BVA** adds extra focus on class edges (boundary and near-boundary values).

They complement each other well.
