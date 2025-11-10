-- Clasifica nodos: Root / Inner / Leaf
SELECT
  t.id,
  CASE
    WHEN t.p_id IS NULL THEN 'Root'
    WHEN EXISTS (SELECT 1 FROM Tree child WHERE child.p_id = t.id) THEN 'Inner'
    ELSE 'Leaf'
  END AS type
FROM Tree t
ORDER BY t.id;